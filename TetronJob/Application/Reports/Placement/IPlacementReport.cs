using Application.Models;
using Domain.Entities;

namespace Application.Reports.Placement
{
    public interface IPlacementReport
    {


        Task<PaginatedList<TDestination>> GetAllPaginatedAsync<TDestination>(PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default);
        Task<PlacementEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
   



        Task<List<PlacementEntity>> GetPlacements(
            Guid? CityId, Guid? ProvinceId, string search = "");
    }
}
