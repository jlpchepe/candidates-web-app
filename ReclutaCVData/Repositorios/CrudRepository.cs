using AppPersistence.Dtos;
using AppPersistence.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AppPersistence.Repositories
{
    /// <summary>
    /// Un repositorio genérico para operaciones con la base de datos
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public interface CrudRepository<TEntity, TPrimaryKey>
        where TEntity : class
    {
        /// <summary>
        /// Encuentra la entidad con la llave primaria especificada en la tabla asociada a <see cref="TEntity"/>
        /// Si no lo encuentra regresa null
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> FindById(TPrimaryKey id);

        /// <summary>
        /// Encuentra la entidad con la llave primaria especificada en la tabla asociada a <see cref="TEntity"/>
        /// Si no lo encuentra regresa null
        /// </summary>
        /// <param name="id"></param>
        /// <param name="include">Hijos de la entidad que necesitan cargarse</param>
        /// <returns></returns>
        Task<TEntity> FindById<TChildren>(
            TPrimaryKey id, 
            Expression<Func<TEntity, ICollection<TChildren>>> include
        ) where TChildren : class;

        /// <summary>
        /// Obtiene todas las entidades en la tabla asociada a la entidad <see cref="TEntity"/>
        /// Después de aplicarle lo indicado
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<TResult>> Find<TResult, TOrder>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TResult, TOrder>> order,
            OrderDirection direction = OrderDirection.Ascending
        );

        /// <summary>
        /// Obtiene el primer resultado que encaje con los criterios establecidos desde la entidad <see cref="TEntity"/>
        /// Si no hay registros que encajen, se regresa null
        /// </summary>
        /// <returns></returns>
        Task<TResult> FindFirstOrDefault<TResult, TOrder>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TResult, TOrder>> order,
            OrderDirection direction = OrderDirection.Ascending
        );

        /// <summary>
        /// Encuentra y entrega en forma paginada todos los elementos que encajen con el filtro especificado
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="selector">Función para transformar los elementos de la consulta</param>
        /// <param name="order">Columnas por la cual se va a ordenar el query, el orden importa</param>
        /// <param name="pageable">Opciones de paginación</param>
        /// <param name="predicate">Filtro a aplicar, puede ser null si no aplican filtros</param>
        /// <returns></returns>
        Task<Page<TResult>> Find<TResult, TOrder>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TResult, TOrder>> order,
            Pageable pageable
        );

        /// <summary>
        /// Determina si hay algún registro que cumpla con la condición establecida
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<bool> Any(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Inserta o actualiza la entidad especificada en función si está o no establecido su llave primaria
        /// Al insertar, establece el ID a las instancias insertadas
        /// </summary>
        /// <param name="entity">Entidad a guardar</param>
        /// <returns></returns>
        Task Save(TEntity entity);

        /// <summary>
        /// Inserta o actualiza un conjunto de entidades
        /// </summary>
        /// <param name="entity">Entidad a guardar</param>
        /// <returns></returns>
        Task Save(IReadOnlyList<TEntity> entity);

        /// <summary>
        /// Elimina por llave primaria una entidad, si la entidad con ID indicado no existe no se hace nada
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteById(TPrimaryKey id);

        /// <summary>
        /// Elimina por llave primaria las entidades, si la entidad con ID indicado no existe no se hace nada
        /// </summary>
        /// <param name="ids">IDs de las entidades a eliminar</param>
        /// <returns></returns>
        Task DeleteById(IEnumerable<TPrimaryKey> ids);
    }
}