using Application.Models;
using Domain.Entities;

namespace Application.Reports.Skill
{
    public interface ISkillReport
    {
        Task<PaginatedList<TDestination>> GetAllPaginatedAsync<TDestination>(PaginatedWithSize pagination,
            CancellationToken cancellationToken = default);
        Task<SkillEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<SkillEntity>> GetSkills(); Task<IEnumerable<SkillEntity>> GetSelectedSkillByIdAsync(List<Guid> ids,
            CancellationToken cancellation);
    }
}
