using Application.Extensions;
using Application.Models;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Reports.Slider
{
    public class SliderReport : ISliderReport
    {
        private readonly IEfRepository<SliderEntity> _repository;

        public SliderReport(IEfRepository<SliderEntity> repository)
        {
            _repository = repository;
        }
        public async Task<PaginatedList<TDestination>> GetAllPaginatedAsync<TDestination>(PaginatedWithSize pagination, CancellationToken cancellationToken = default)
        {
            var query = await _repository.GetByQueryAsync();
            // Apply search filter.
            return await query.PaginatedListAsync<SliderEntity, TDestination>(pagination.Page, pagination.PageSize,
                config: null, cancellationToken);
        }

        public async Task<SliderEntity> GetByIdAsync
            (Guid id, CancellationToken cancellationToken = default)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<SliderEntity>> GetWithPositionAsync(PositionEnum? position)
        {
            var query= await _repository.GetByQueryAsync();
            return await query.Where(w => w.Position == position).ToListAsync();
        }
    }
}
