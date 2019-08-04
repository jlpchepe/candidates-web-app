using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using ReclutaCVApi.Properties;

namespace ReclutaCVApi.Attributes
{
    /// <summary>
    /// Atributo que valida un parámetro número requerido y mayor o igual a cierto valor
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class MinRequiredAttribute : DataTypeAttribute
    {
        public object Min { get { return min; } }

        private readonly double min;

        public MinRequiredAttribute(int min) : base("min")
        {
            this.min = min;
        }

        public MinRequiredAttribute(double min) : base("min")
        {
            this.min = min;
        }

        public override string FormatErrorMessage(string name)
        {
            if (ErrorMessage == null && ErrorMessageResourceName == null)
            {
                ErrorMessage = Resources.FormatErrorMessage;
            }

            return string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, min);
        }

        public override bool IsValid(object value)
        {
            if (value == null) return false;

            var isDouble = double.TryParse(Convert.ToString(value), out var valueAsDouble);

            return isDouble && valueAsDouble >= min;
        }
    }
}