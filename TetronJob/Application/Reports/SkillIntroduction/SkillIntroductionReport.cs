using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Reports.SkillIntroduction
{
    public class SkillIntroductionReport: ISkillIntroductionReport
    {
        private readonly IEfRepository<SkillIntroductionEntity> _repository;

        public SkillIntroductionReport(IEfRepository<SkillIntroductionEntity> repository)
        {
            _repository = repository;
        }
        public async Task<List<Guid?>> GetSkillsOfIntroductionAsync(Guid id)
        {
            var model = await _repository.GetByQueryAsync();
            return await model.Where(w=>w.IntroductionId==id).Select(s => s.SkillId)
                .ToListAsync();
        }

        public async Task<List<SkillIntroductionEntity>?> GetSkillsByIntroductionIdAsync(Guid id)
        {
            var model = await _repository.GetByQueryAsync();
            return await model.Where(w => w.IntroductionId == id).ToListAsync();
        }
    }
}
