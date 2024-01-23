using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Reports.Recruitment
{
    public class RecruitmentReport : IRecruitmentReport
    {
        private readonly IEfRepository<RecruitmentEntity> _repository;

        public RecruitmentReport(IEfRepository<RecruitmentEntity> repository)
        {
            _repository = repository;
        }
        public async Task<List<RecruitmentEntity>> GetRecruitments(Guid? CityId, Guid? ProvinceId, string search = "")
        {
            var query = await _repository.GetByQueryAsync();
            query.Include(i => i.User);
            if (ProvinceId != Guid.Empty)
            {
                query = query.Where(w => w.ProvinceId == ProvinceId);
            }
            if (CityId != Guid.Empty)
            {
                query = query.Where(w => w.CityId == CityId);
            }

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(w => w.RecruitmentTitle.Contains(search));
            }
            return query.ToList();
        }
    }
}
