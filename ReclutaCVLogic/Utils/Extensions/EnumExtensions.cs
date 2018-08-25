using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutaCVLogic.Utils.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .SingleOrDefault() as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }

        /// <summary>
        /// Enumerates all enum values
        /// </summary>
        /// <typeparam name="T">Enum type</typeparam>
        /// <returns>IEnumerable containing all enum values</returns>
        /// <see cref="http://stackoverflow.com/questions/972307/can-you-loop-through-all-enum-values"/>
        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}
