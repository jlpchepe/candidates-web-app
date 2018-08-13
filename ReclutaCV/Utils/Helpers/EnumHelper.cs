using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCV.Utils.Helpers
{
    public static class EnumHelper
    {
        public static List<Tuple<object, string, int>> EnumToList(Type t)
        {
            return Enum
                .GetValues(t)
                .Cast<object>()
                .Select(x => Tuple.Create(x, x.ToString(), (int)x))
                .ToList();
        }
    }
}
