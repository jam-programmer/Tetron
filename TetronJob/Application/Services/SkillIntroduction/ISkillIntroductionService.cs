using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Domain.Entities;

namespace Application.Services.SkillIntroduction
{
    public interface ISkillIntroductionService
    {
        Task<Response> InsertAsync(List<SkillIntroductionEntity> skills);
        Task InsertAsync(SkillIntroductionEntity skill);
    }
}
