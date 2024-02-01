using Application.Models;
using Domain.Entities;
using Domain.Enums;

namespace Application.Reports.Slider
{
    public interface ISliderReport
    {
        Task<PaginatedList<TDestination>> GetAllPaginatedAsync<TDestination>(PaginatedWithSize pagination,
            CancellationToken cancellationToken = default);
        Task<SliderEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<List<SliderEntity>> GetWithPositionAsync(PositionEnum? position);
    }
}
