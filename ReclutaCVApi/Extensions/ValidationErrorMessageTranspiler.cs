using System.Collections.Generic;
using System.Linq;
using AppPersistence.Exceptions;

namespace ReclutaCVApi.Extensions
{
    /// <summary>
    /// Transpilador de mensajes de error a partir de errores de validación <see cref="ValidationErrorException"/>
    /// </summary>
    internal class ValidationErrorMessageTranspiler
    {
        /// <summary>
        /// A partir de la excepción de validación, obtiene el mensaje amigable de validación
        /// Si no encuentra el mensaje amigable, regresa un código de error
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public string TranspileFriendlyMessage(ValidationErrorException error)
        {
            var errorCode =
                $"{string.Join("-", error.Properties)}:{error.Type.ToString()}".ToUpper();

            var errorTranslationExist =
                translationTable.TryGetValue(errorCode, out var errorMessage);

            return errorTranslationExist ? errorMessage : errorCode;
        }

        /// <summary>
        /// Diccionario que contiene la relación entre el código de error de validación y el mensaje al que equivale
        /// </summary>
        /// <remarks>La clave es el código de error y el valor es el mensaje amigable</remarks>
        private readonly IReadOnlyDictionary<string, string> translationTable =
            new Dictionary<string, string>
            {
                { "ACTIVO:REQUIRED", "El estatus es requerido" },
                { "NOMBRE:REQUIRED", "El nombre es requerido" },
                { "CONTRASEÑA:REQUIRED", "La contraseña es requerida" }
            }
            .ToDictionary(x => x.Key.ToUpper(), x => x.Value);
    }
}