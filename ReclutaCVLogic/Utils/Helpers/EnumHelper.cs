using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVLogic.Utils.Helpers
{
    public static class EnumHelper
    {
        public static List<Enum> ObtenerListadoDeValoresDeTipoEnum(Type t)
        {
            return Enum
                .GetValues(t)
                .Cast<Enum>()
                .ToList();
        }
    }
}
