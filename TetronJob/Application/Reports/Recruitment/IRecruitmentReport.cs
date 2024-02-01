using Application.Models;
using Domain.Entities;

namespace Application.Reports.Recruitment
{
    public interface IRecruitmentReport
    {


        Task<PaginatedList<TDestination>> GetAllPaginatedAsync<TDestination>(PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default);
        Task<RecruitmentEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);






        Task<List<RecruitmentEntity>> GetRecruitments(
            Guid? CityId, Guid? ProvinceId, string search = "");
    }
}
