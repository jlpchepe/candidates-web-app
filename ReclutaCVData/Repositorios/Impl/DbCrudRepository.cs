using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AppPersistence.Validators;
using AppPersistence.Dtos;
using AppPersistence.Enums;
using AppPersistence.Extensions;
using Npgsql;
using ReclutaCVData;

namespace AppPersistence.Repositories.Impl
{
    /// <summary>
    /// Un repositorio que realiza las operaciones CRUD a una entidad
    /// </summary>
    public class DbCrudRepository<TEntity, TPrimaryKey> : CrudRepository<TEntity, TPrimaryKey>
        where TEntity : class
    {
        public DbCrudRepository(
            DbRepository dbRepository,
            ModelValidator modelValidator
        )
        {
            this.dbRepository = dbRepository;
            this.modelValidator = modelValidator;
        }

        private readonly DbRepository dbRepository;
        private readonly ModelValidator modelValidator;

        /// <summary>
        /// Encuentra la entidad con la llave primaria especificada en la tabla asociada a <see cref="TEntity"/>
        /// Si no lo encuentra regresa null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<TEntity> FindById(TPrimaryKey id) =>
            id != null ?
                ExecuteInContext<TEntity>((db, dbSet) => dbSet.FindAsync(id)) :
                Task.FromResult((TEntity)null);

        /// <summary>
        /// Encuentra la entidad con la llave primaria especificada en la tabla asociada a <see cref="TEntity"/>
        /// Si no lo encuentra regresa null
        /// </summary>
        /// <param name="id"></param>
        /// <param name="include">Expresión que indica qué hijos de la entidad deben cargarse</param>
        /// <returns></returns>
        public Task<TEntity> FindById<TChildren>(
            TPrimaryKey id,
            Expression<Func<TEntity, ICollection<TChildren>>> include
        ) where TChildren : class
        {
            return ExecuteInContext(async (db, dbSet) =>
            {
                var entity = await dbSet.FindAsync(id);

                if (entity != null && include != null)
                {
                    await db.Entry(entity).Collection(include).LoadAsync();
                }

                return entity;
            });
        }

        /// <summary>
        /// Prepara una consulta a partir de los parametros de selección, filtrado y orden indicados
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TOrder"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="selector"></param>
        /// <param name="predicate"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        private IOrderedQueryable<TResult> PrepareQueryable<TResult, TOrder>(
            DbSet<TEntity> dbSet,
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TResult, TOrder>> order,
            OrderDirection direction
        )
        {
            Expression<Func<TEntity, bool>> defaultPredicate = entity => true;

            // Por defecto, no se rastrearán los cambios
            var filteredQuery =
                dbSet
                .AsNoTracking()
                .Where(predicate ?? defaultPredicate)
                .Select(selector);

            return direction == OrderDirection.Ascending ?
                filteredQuery.OrderBy(order) :
                filteredQuery.OrderByDescending(order);
        }

        public Task<TResult> FindFirstOrDefault<TResult, TOrder>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TResult, TOrder>> order,
            OrderDirection direction = OrderDirection.Ascending
        ) => ExecuteInContext((db, dbSet) =>
            {
                var query = PrepareQueryable(
                    dbSet,
                    selector,
                    predicate,
                    order,
                    direction
                );

                return query.FirstOrDefaultAsync();
            });

        /// <summary>
        /// Obtiene todas las entidades en la tabla asociada a la entidad <see cref="TEntity"/> que cumplen con lo indicado
        /// </summary>
        /// <returns></returns>
        public Task<IReadOnlyList<TResult>> Find<TResult, TOrder>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TResult, TOrder>> order,
            OrderDirection direction = OrderDirection.Ascending
        ) => ExecuteInContext(async (db, dbSet) =>
        {
            var query =
               PrepareQueryable(
                   dbSet,
                   selector,
                   predicate,
                   order,
                   direction
               );

            IReadOnlyList<TResult> result =
                await query.ToListAsync();

            return result;
        });

        /// <summary>
        /// Encuentra y entrega en forma paginada todos los elementos que encajen con el filtro especificado
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="selector">Función para transformar los elementos de la consulta</param>
        /// <param name="order">Columnas por la cual se va a ordenar el query, el orden importa</param>
        /// <param name="pageable">Opciones de paginación</param>
        /// <param name="predicate">Filtro a aplicar, puede ser null si no aplican filtros</param>
        /// <returns></returns>
        public Task<Page<TResult>> Find<TResult, TOrder>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TResult, TOrder>> order,
            Pageable pageable
        ) => ExecuteInContext((db, dbSet) =>
            {
                var query = PrepareQueryable(
                    dbSet,
                    selector,
                    predicate,
                    order,
                    pageable.OrderDirection
                );

                return query.PaginateQueryAsync(pageable);
            });

        /// <summary>
        /// Determina si hay algún registro que cumpla con la condición establecida
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Task<bool> Any(
            Expression<Func<TEntity, bool>> predicate
        ) => ExecuteInContext((db, dbSet) =>
        {
            var query = PrepareQueryable(
                dbSet,
                entity => entity,
                predicate,
                entity => true,
                OrderDirection.Ascending
            );

            return query.AnyAsync();
        });

        /// <summary>
        /// Inserta o actualiza la entidad especificada en función si está o no establecido su llave primaria
        /// </summary>
        /// <param name="entity">Entidad a guardar</param>
        /// <returns></returns>
        public Task Save(TEntity entity) => Save(new[] { entity });

        /// <summary>
        /// Inserta o actualiza la entidad especificada en función si está o no establecido su llave primaria
        /// </summary>
        /// <param name="entity">Entidad a guardar</param>
        /// <returns></returns>
        public Task Save(IReadOnlyList<TEntity> entities) =>
            entities.Any() ?
                ExecuteInContext(async (db, dbSet) =>
                {
                    foreach (var entity in entities)
                    {
                        // Se valida la entidad, si hay algún error se arroja una excepción
                        await modelValidator.ValidateOrThrow(
                            dbSet,
                            entity
                        );

                        AddOrUpdate(dbSet, entity);
                    }

                    return await db.SaveChangesAsync();
                }) :
                Task.CompletedTask;

        /// <summary>
        /// Elimina por llave primaria una entidad
        /// </summary>
        /// <param name="id">Si no hay entidad con este ID, no hace nada</param>
        /// <returns></returns>
        public async Task DeleteById(TPrimaryKey id) => 
            await DeleteById(new[] { id });

        /// <summary>
        /// Elimina por llave primaria las entidades especificadas
        /// </summary>
        /// <param name="ids">IDs de las entidades a eliminar, si no hay entidad con alguno de los ids</param>
        /// <returns></returns>
        public Task DeleteById(IEnumerable<TPrimaryKey> ids) =>
            ExecuteInContext(async (db, dbSet) =>
            {
                foreach (var id in ids)
                {
                    var entity = await dbSet.FindAsync(id);

                    if (entity != null)
                    {
                        dbSet.Remove(entity);
                    }
                }

                return await db.SaveChangesAsync();
            });

        /// <summary>
        /// Inserta o actualiza la entidad en el contexto especificado
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="entity"></param>
        private void AddOrUpdate(
            IDbSet<TEntity> ctx,
            TEntity entity
        )
        {
            ctx.AddOrUpdate(entity);
        }

        /// <summary>
        /// Ejecuta una operación dependiente del contexto y del DataSet de la entidad <see cref="TEntity"/>
        /// Esto abre una sesión con la base de datos, ejecuta la operación y retorna el resultado correspondiente
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="action"></param>
        /// <returns></returns>
        private Task<TResult> ExecuteInContext<TResult>(
            Func<Db, DbSet<TEntity>, Task<TResult>> action
        ) => dbRepository.ExecuteInContext((db) => action(db, db.Set<TEntity>()));
    }
}