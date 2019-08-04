using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReclutaCVApi.Dtos
{
    /// <summary>
    /// Una respuesta resultante de un error de validación
    /// </summary>
    public class ValidationErrorResponse
    {
        public ValidationErrorResponse(string message)
        {
            Message = message;
        }

        /// <summary>
        /// Indica que el error es de validación
        /// </summary>
        public bool IsValidationError => true;

        /// <summary>
        /// Mensaje de error
        /// </summary>
        public string Message { get; }
    }
}
