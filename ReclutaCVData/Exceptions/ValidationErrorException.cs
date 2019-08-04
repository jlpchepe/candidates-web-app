using System;
using System.Collections.Generic;
using System.Text;
using AppPersistence.Enums;

namespace AppPersistence.Exceptions
{
    /// <summary>
    /// Una excepción originada por una excepción de validación
    /// </summary>
    public class ValidationErrorException: Exception
    {
        public ValidationErrorException(
            string property,
            ValidationErrorType type
        ) : this(
                new[] { property }, 
                type
            ) {}

        public ValidationErrorException(
            IReadOnlyList<string> properties,
            ValidationErrorType type
        )
        {
            Properties = properties;
            Type = type;
        }

        /// <summary>
        /// Nombre de las propiedades que están incluidas en la validación
        /// </summary>
        public IReadOnlyList<string> Properties { get; }

        /// <summary>
        /// Tipo de error
        /// </summary>
        public ValidationErrorType Type { get; }

        /// <summary>
        /// Crea una excepción de tipo <see cref="ValidationErrorType.Required"/>
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static ValidationErrorException Required(string property) =>
            new ValidationErrorException(property, ValidationErrorType.Required);
    }
}
