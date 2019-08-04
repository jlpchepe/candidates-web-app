using System;

namespace AppPersistence.Extensions
{
    /// <summary>
    /// Clase con extensiones para la validación de campos, argumentos o parámetros
    /// </summary>
    public static class AssertExtensions
    {
        /// <summary>
        /// Arroja una excepción si el parámetro indicado es null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <param name="paramName"></param>
        /// <returns></returns>
        internal static T ThrowIfNull<T>(this T o, string paramName) where T : class
        {
            if (o == null)
                throw new ArgumentNullException(paramName);

            return o;
        }
    }
}
