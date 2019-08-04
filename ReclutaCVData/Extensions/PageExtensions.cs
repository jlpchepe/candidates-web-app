using System;
using System.Linq;
using AppPersistence.Dtos;

namespace AppPersistence.Extensions
{
    /// <summary>
    /// Métodos de extensión para la clase <see cref="AppPersistence.Dtos.Page{TItem}"/>
    /// </summary>
    public static class PageExtensions
    {
        /// <summary>
        /// Mapea los elementos de la página a otro tipo
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="page"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static Page<TResult> Select<TResult, TItem>(
            this Page<TItem> page,
            Func<TItem, TResult> selector
        )
        {
            return new Page<TResult>(
                page.Items.Select(selector).ToList(),
                page.TotalPages
            );
        }
    }
}
