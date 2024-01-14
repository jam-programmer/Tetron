using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Skill
{
    public interface ISkillService
    {
        Task<Response> InsertAsync(SkillEntity skill, CancellationToken cancellationToken);
        Task<Response> UpdateAsync(SkillEntity skill, CancellationToken cancellationToken);
        Task<Response> DeleteAsync(SkillEntity skill, CancellationToken cancellationToken);
    }
}
