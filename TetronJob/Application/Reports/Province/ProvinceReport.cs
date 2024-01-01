using Application.Extensions;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
namespace Application.Reports.Province
{
    public class ProvinceReport : IProvinceReport
    {
        private readonly IEfRepository<ProvinceEntity> _repository;

        public ProvinceReport(IEfRepository<ProvinceEntity> repository)
        {
            _repository = repository;
        }
        public async Task<PaginatedList<TDestination>> GetAllPaginatedAsync<TDestination>(PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default)
        {
            var query = await _repository.GetByQueryAsync();

            // Apply search filter.
            if (!string.IsNullOrEmpty(pagination.Keyword))
            {
                query = query
                    .Where(r => r.Name!.Contains(pagination.Keyword))
                    .AsQueryable();
            }

            return await query.PaginatedListAsync<ProvinceEntity, TDestination>(pagination.Page, pagination.PageSize,
                config: null, cancellationToken);

        }

        public async Task<ProvinceEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
            {

            }

            

            var province = await _repository.GetByIdAsync(id);
            return province;
        }
    }
}
