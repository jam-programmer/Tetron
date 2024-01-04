using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Reports.City
{
    public interface ICityReport
    {
        Task<PaginatedList<TDestination>> GetAllPaginatedAsync<TDestination>(PaginatedSearchWithSize pagination,Guid provinceId,
            CancellationToken cancellationToken = default);
        Task<CityEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
