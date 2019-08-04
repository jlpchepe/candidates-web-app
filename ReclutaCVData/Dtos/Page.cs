using System.Collections.Generic;

namespace AppPersistence.Dtos
{
    public class Page<TItem>
    {
        public Page(
            IReadOnlyList<TItem> items,
            int totalPages
        )
        {
            Items = items;
            TotalPages = totalPages;
        }

        public IReadOnlyList<TItem> Items { get; }
        public int TotalPages { get; }
    }
}
