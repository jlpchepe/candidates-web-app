using System;
using AppPersistence.Enums;

namespace AppPersistence.Dtos
{
    public class Pageable
    {
        public Pageable(
            int pageNumber, 
            int pageSize,
            OrderDirection orderDirection = OrderDirection.Ascending
        )
        {
            if (pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize), "Debe ser mayor que cero");
            }

            if (pageNumber < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageNumber), "Debe ser mayor o igual que cero");
            }

            PageNumber = pageNumber;
            PageSize = pageSize;
            OrderDirection = orderDirection;
        }

        /// <summary>
        /// Número de página basado en cero
        /// </summary>
        public int PageNumber { get; }
        /// <summary>
        /// Número de elementos por página
        /// </summary>
        public int PageSize { get; }
        /// <summary>
        /// Dirección de ordenamiento
        /// </summary>
        public OrderDirection OrderDirection { get; }
    }
}