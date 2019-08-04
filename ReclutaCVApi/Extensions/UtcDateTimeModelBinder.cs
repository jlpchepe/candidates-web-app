using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace ReclutaCVApi.Extensions
{
    public class UtcDateTimeModelBinder : IModelBinder
    {
        private static readonly string[] dateTimeFormats = { "yyyy-MM-dd", "yyyy-MM-dd'T'HH:mm:ss.FFFZ" };

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            var stringValue = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).FirstValue;

            if (
                bindingContext.ModelType == typeof(DateTime?) && 
                string.IsNullOrEmpty(stringValue)
            )
            {
                bindingContext.Result = ModelBindingResult.Success(null);
                return Task.CompletedTask;
            }

            bindingContext.Result =
                DateTime.TryParseExact(
                    stringValue,
                    dateTimeFormats,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.RoundtripKind,
                    out var result
                ) ? 
                    ModelBindingResult.Success(result) :
                    ModelBindingResult.Failed();

            return Task.CompletedTask;
        }
    }

    public class UtcDateTimeModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (context.Metadata.ModelType != typeof(DateTime) &&
                context.Metadata.ModelType != typeof(DateTime?))
                return null;

            return new BinderTypeModelBinder(typeof(UtcDateTimeModelBinder));
        }
    }
}
