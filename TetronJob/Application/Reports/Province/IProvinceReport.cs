using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Reports.Province
{
    public interface IProvinceReport
    {
        Task<PaginatedList<TDestination>> GetAllPaginatedAsync<TDestination>(PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default);
        Task<ProvinceEntity> GetByIdAsync(Guid id,CancellationToken cancellationToken = default);
    }
}
