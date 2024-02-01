using Application.Models;
using Domain.Entities;

namespace Application.Reports.Introduction
{
    public interface IIntroductionReport
    {
        Task<PaginatedList<TDestination>> GetAllPaginatedAsync<TDestination>(PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default);
        Task<IntroductionEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);



        Task<List<IntroductionEntity>> GetIntroductions(
            Guid? CityId, Guid? ProvinceId, string search = "");
    }
}
