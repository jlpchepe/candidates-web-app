using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AppPersistence.Dtos;

namespace AppPersistence.Extensions
{
    /// <summary>
    /// Métodos de extensión para la interfaze <see cref="IQueryable{T}"/>
    /// </summary>
    public static class IQueryableExtensions
    {
        /// <summary>
        /// Pagina y ejecuta la consulta especificada.
        /// Este método debe ejecutarse en el tiempo de vida de un contexto.
        /// Si se ejecuta fuera de un contexto arrojará una excepción de EF.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="query">Consulta a paginar y ejecutar</param>
        /// <param name="pageable">Opciones de paginación</param>
        /// <returns></returns>
        public static async Task<Page<TResult>> PaginateQueryAsync<TResult>(
            this IQueryable<TResult> query,
            Pageable pageable
        )
        {
            pageable.ThrowIfNull(nameof(pageable));

            var pageSize = pageable.PageSize;
            var pageNumber = pageable.PageNumber;

            var totalRecords = await query.CountAsync();

            var totalPages =
                (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize);

            var items =
                await query
                .Skip(pageNumber * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new Page<TResult>(items, totalPages);
        }
    }
}
