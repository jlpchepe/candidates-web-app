using ReclutaCVData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppPersistence.Repositories.Impl
{
    /// <summary>
    /// Un repositorio que se encarga de realizar operaciones en la base de datos
    /// </summary>
    public class DbRepository
    {
        public DbRepository(Func<Db> dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        /// <summary>
        /// Función que obtiene una sesión con la base de datos
        /// </summary>
        private readonly Func<Db> dbFactory;

        /// <summary>
        /// Ejecuta una operación dependiente del contexto y del DataSet de la entidad <see cref="TEntity"/>
        /// Esto abre una sesión con la base de datos, ejecuta la operación y retorna el resultado correspondiente
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="action"></param>
        /// <returns></returns>
        public async Task<TResult> ExecuteInContext<TResult>(
            Func<Db, Task<TResult>> action
        )
        {
            using (var c = dbFactory())
            {
                return await action(c);
            }
        }
    }
}
