using Application.Extensions;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Reports.Introduction
{
    public class IntroductionReport : IIntroductionReport
    {
        private readonly IEfRepository<IntroductionEntity> _repository;

        public IntroductionReport(IEfRepository<IntroductionEntity> repository)
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
                    .Where(r => r.IntroductionTitle!.Contains(pagination.Keyword))
                    .AsQueryable();
            }

            return await query.PaginatedListAsync<IntroductionEntity, TDestination>(pagination.Page, pagination.PageSize,
                config: null, cancellationToken);
        }

        public async Task<IntroductionEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var query = await _repository.GetByQueryAsync();
            query = query.Include(i => i.Province);
            query = query.Include(i => i.User);
            query = query.Include(i => i.City);
            return await query.SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<IntroductionEntity>> GetIntroductions
            (Guid? CityId, Guid? ProvinceId, string search = "")
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
                query = query.Where(w => w.IntroductionTitle.Contains(search));
            }
            return query.ToList();
        }
    }
}
