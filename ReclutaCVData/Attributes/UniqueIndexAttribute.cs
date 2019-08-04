using System;
using System.Collections.Generic;
using System.Text;

namespace AppPersistence.Attributes
{
    /// <summary>
    /// Atributo que indica que una propiedad o conjunto de propiedades es única
    /// CUIDADO: Este atríbuto no genera el índice único con EF, para ello se debe usar el Fluent API
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]

    public class UniqueIndexAttribute: Attribute
    {
    }
}
