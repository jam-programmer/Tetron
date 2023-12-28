using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Mapster;

namespace Application.Extensions
{
    public static class MappingExtensions
    {
        public static Task<PaginatedList<TOrigin>> PaginatedListAsync<TOrigin>(this IQueryable<TOrigin> queryable,
            int pageNumber, int pageSize, CancellationToken cancellationToken = default)
            => PaginatedList<TOrigin>.CreateAsync(queryable, pageNumber, pageSize, cancellationToken);

        public static
            Task<PaginatedList<TDestination>>
            PaginatedListAsync<TOrigin, TDestination>

            (this IQueryable<TOrigin> queryable, int pageNumber, int pageSize, TypeAdapterConfig? config = default, CancellationToken cancellationToken = default)
            =>

                PaginatedList<TDestination>.CreateAsync<TOrigin, TDestination>(queryable, pageNumber, pageSize,
                    config, cancellationToken);
    }
}
