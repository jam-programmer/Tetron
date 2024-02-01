using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Extensions;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Reports.Skill
{
    public class SkillReport:ISkillReport
    {
        private readonly IEfRepository<SkillEntity> _repository;

        public SkillReport(IEfRepository<SkillEntity> repository)
        {
            _repository = repository;
        }
        public async Task<PaginatedList<TDestination>> GetAllPaginatedAsync<TDestination>(PaginatedWithSize pagination,
            CancellationToken cancellationToken = default)
        {
            var query = await _repository.GetByQueryAsync();

            // Apply search filter.
            

            return await query.PaginatedListAsync<SkillEntity, TDestination>(pagination.Page, pagination.PageSize,
                config: null, cancellationToken);

        }

        public async Task<SkillEntity> GetByIdAsync(Guid? id, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                //todo
            }
            return await _repository.GetByIdAsync(id.Value);
        }

        public async Task<IEnumerable<SkillEntity>> GetSkills()
        {
            return await _repository.GetListAsync();
        }


        public async Task<IEnumerable<SkillEntity>> GetSelectedSkillByIdAsync(List<Guid> ids,
            CancellationToken cancellation)
        {
            var query =await _repository.GetByQueryAsync();
            query = query.Where(w => ids.Contains(w.Id));
            return await query.ToListAsync(cancellation);
        }
    }
}
