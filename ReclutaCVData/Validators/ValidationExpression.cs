using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using AppPersistence.Enums;

namespace AppPersistence.Validators
{
    /// <summary>
    /// Una expresión que valida el modelo, si el resultado de la expresión es false,
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    class ValidationExpression<TModel> where TModel : class
    {
        public ValidationExpression(
            Expression<Func<TModel, bool>> isInvalidPredicate, 
            IReadOnlyList<string> properties, 
            ValidationErrorType type
        )
        {
            IsInvalidPredicate = isInvalidPredicate;
            Properties = properties;
            Type = type;
        }

        /// <summary>
        /// Expresión que se usará para filtrar las entidades del set al que pertenezca la entidad
        /// En caso de que alguna entidad del set pase el filtro, se lanzará este error de validación
        /// </summary>
        public Expression<Func<TModel, bool>> IsInvalidPredicate { get; set; }
        /// <summary>
        /// Propiedades que se involucran en la validación
        /// </summary>
        public IReadOnlyList<string> Properties { get; set; }
        /// <summary>
        /// Tipo de error de validación
        /// </summary>
        public ValidationErrorType Type { get; set; }
    }
}