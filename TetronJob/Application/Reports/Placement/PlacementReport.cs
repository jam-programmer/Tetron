using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Reports.Placement
{
    public class PlacementReport:IPlacementReport
    {
        private readonly IEfRepository<PlacementEntity> _repository;

        public PlacementReport(IEfRepository<PlacementEntity> repository)
        {
            _repository = repository;
        }
        public async Task<List<PlacementEntity>> 
            GetPlacements(Guid? CityId, Guid? ProvinceId, string search = "")
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
                query = query.Where(w => w.PlacementFullName.Contains(search));
            }
            return query.ToList();
        }
    }
}
