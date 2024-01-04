using Application.Models;
using Domain.Entities;

namespace Application.Reports.Province
{
    public interface IProvinceReport
    {
        Task<PaginatedList<TDestination>> GetAllPaginatedAsync<TDestination>(PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default);
        Task<ProvinceEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
