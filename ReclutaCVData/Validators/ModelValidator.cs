using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPersistence.Validators
{
    /// <summary>
    /// Un validador de un modelo
    /// </summary>
    public interface ModelValidator
    {
        /// <summary>
        /// Arroja una excepción con el primer error de validación que tiene el modelo
        /// Si el modelo es válido, no hace nada
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="model">Módelo que se validará</param>
        /// <param name="set">Conjunto al que pertenece el modelo</param>
        /// <exception cref="AppPersistence.Exceptions.ValidationErrorException"></exception>
        Task ValidateOrThrow<TModel>(IQueryable<TModel> set, TModel model) where TModel : class;
    }
}
