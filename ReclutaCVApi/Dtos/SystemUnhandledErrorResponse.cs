using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReclutaCVApi.Dtos
{
    /// <summary>
    /// Representa una respuesta que se da ante la situación donde el servidor no pudo manejar correctamente un error
    /// Este error casi siempre indicará bugs en el sistema que deben ser atendidos a la brevedad
    /// </summary>
    public class SystemUnhandledErrorResponse
    {
        /// <summary>
        /// Crea una respuesta de error no manejado por el sistema
        /// </summary>
        /// <param name="error"></param>
        public SystemUnhandledErrorResponse(Exception error)
        {
            ExceptionMessage = error.Message;
            ExceptionStackTrace = error.StackTrace;
        }

        /// <summary>
        /// Determina si el error es debido a una falla o condición no manejada por el sistema
        /// </summary>
        public bool IsSystemError => true;

        /// <summary>
        /// Mensaje para mostrarle al usuario
        /// </summary>
        public string Message => "Error en sistema. Contacte a soporte";

        /// <summary>
        /// Mensaje de la excepción
        /// </summary>
        public string ExceptionMessage { get; set; }

        /// <summary>
        /// Rastreo del lugar en el que se originó la excepción
        /// </summary>
        public string ExceptionStackTrace { get; set; }
    }
}
