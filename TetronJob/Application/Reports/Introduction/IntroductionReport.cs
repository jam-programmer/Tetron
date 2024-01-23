using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Reports.Introduction
{
    public class IntroductionReport: IIntroductionReport
    {
        private readonly IEfRepository<IntroductionEntity> _repository;

        public IntroductionReport(IEfRepository<IntroductionEntity> repository)
        {
            _repository = repository;
        }
        public async Task<List<IntroductionEntity>> GetIntroductions
            (Guid? CityId, Guid? ProvinceId, string search = "")
        {
            var query =await _repository.GetByQueryAsync();
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
                query = query.Where(w => w.IntroductionTitle.Contains(search));
            }
            return query.ToList();
        }
    }
}
