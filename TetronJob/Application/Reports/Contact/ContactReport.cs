
using Application.Extensions;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Reports.Contact
{
    public class ContactReport: IContactReport
    {
        private readonly IEfRepository<ContactUsEntity> _repository;
        public ContactReport(IEfRepository<ContactUsEntity> contactUsRepository)
        {
            _repository = contactUsRepository;
        }
        public async Task<PaginatedList<TDestination>> GetAllPaginatedAsync<TDestination>(PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default)
        {
            var query = await _repository.GetByQueryAsync();

            // Apply search filter.
            if (!string.IsNullOrEmpty(pagination.Keyword))
            {
                query = query
                    .Where(r => r.Title!.Contains(pagination.Keyword))
                    .AsQueryable();
            }

            return await query.PaginatedListAsync<ContactUsEntity, TDestination>(pagination.Page, pagination.PageSize,
                config: null, cancellationToken);
        }
    }
}
