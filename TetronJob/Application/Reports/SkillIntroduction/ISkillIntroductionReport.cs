using Domain.Entities;

namespace Application.Reports.SkillIntroduction
{
    public interface ISkillIntroductionReport
    {
        Task<List<Guid?>> GetSkillsOfIntroductionAsync(Guid id);
        Task<List<SkillIntroductionEntity>?> GetSkillsByIntroductionIdAsync(Guid id);
    }
}
