using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPersistence.Enums
{
    /// <summary>
    /// Tipos de validación
    /// CUIDADO: Al cambiar los nombres de estos enum, ya que los mensajes de error de la aplicación dependen de ellos
    /// </summary>
    public enum ValidationErrorType
    {
        Required,
        Unique,
        Invalid
    }
}
