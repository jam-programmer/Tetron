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

namespace Application.Reports.City
{
    public class CityReport:ICityReport
    {
        private readonly IEfRepository<CityEntity> _repository;

        public CityReport(IEfRepository<CityEntity> repository)
        {
            _repository = repository;
        }
        public async Task<PaginatedList<TDestination>> GetAllPaginatedAsync<TDestination>(PaginatedSearchWithSize pagination, Guid provinceId,
            CancellationToken cancellationToken = default)
        {
            var query = await _repository.GetByQueryAsync();
             query = query.Where(w => w.ProvinceId == provinceId);
             query = query.Include(i => i.Province);

            // Apply search filter.
            if (!string.IsNullOrEmpty(pagination.Keyword))
            {
                query = query
                    .Where(r => r.Name!.Contains(pagination.Keyword))
                    .AsQueryable();
            }

            return await query.PaginatedListAsync<CityEntity, TDestination>(pagination.Page, pagination.PageSize,
                config: null, cancellationToken);

        }

        public async Task<CityEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
            {

            }



            var province = await _repository.GetByIdAsync(id);
            return province;
        }
    }
}
