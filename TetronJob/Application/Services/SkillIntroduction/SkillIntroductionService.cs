using Application.Models;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services.SkillIntroduction
{
    public class SkillIntroductionService : ISkillIntroductionService
    {
        private readonly IEfRepository<SkillIntroductionEntity> _repository;

        public SkillIntroductionService(IEfRepository<SkillIntroductionEntity> repository)
        {
            _repository = repository;
        }
        public async Task<Response> InsertAsync(List<SkillIntroductionEntity> skills)
        {
            try
            {
                await _repository.InsertListAsync(skills);
                return Response.Succeded();
            }
            catch (Exception e)
            {
                return Response.Fail("عملیات با خطا مواجه شد.");
            }
        }

        public async Task InsertAsync(SkillIntroductionEntity skill)
        {
            try
            {
                await _repository.InsertAsync(skill);
              
            }
            catch (Exception e)
            {
         
            }
        }
    }
}
