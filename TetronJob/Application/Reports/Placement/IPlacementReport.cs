using Domain.Entities;

namespace Application.Reports.Placement
{
    public interface IPlacementReport
    {
        Task<List<PlacementEntity>> GetPlacements(
            Guid? CityId, Guid? ProvinceId, string search = "");
    }
}
