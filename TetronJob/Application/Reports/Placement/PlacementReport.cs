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

namespace Application.Reports.Placement
{
    public class PlacementReport:IPlacementReport
    {
        private readonly IEfRepository<PlacementEntity> _repository;

        public PlacementReport(IEfRepository<PlacementEntity> repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedList<TDestination>> GetAllPaginatedAsync<TDestination>(PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default)
        {
            var query = await _repository.GetByQueryAsync();

            // Apply search filter.
            if (!string.IsNullOrEmpty(pagination.Keyword))
            {
                query = query
                    .Where(r => r.PlacementFullName!.Contains(pagination.Keyword))
                    .AsQueryable();
            }

            return await query.PaginatedListAsync<PlacementEntity, TDestination>(pagination.Page, pagination.PageSize,
                config: null, cancellationToken);
        }

        public async Task<PlacementEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _repository.GetByIdAsync(id);
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
