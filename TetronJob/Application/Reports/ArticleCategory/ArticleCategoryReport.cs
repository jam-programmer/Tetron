using Application.Extensions;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Reports.ArticleCategory
{
    public class ArticleCategoryReport : IArticleCategoryReport
    {
        private readonly IEfRepository<ArticleCategoryEntity> _repository;

        public ArticleCategoryReport(IEfRepository<ArticleCategoryEntity> repository)
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
                    .Where(r => r.ArticleCategoryTitle!.Contains(pagination.Keyword))
                    .AsQueryable();
            }

            return await query.PaginatedListAsync<ArticleCategoryEntity, TDestination>(pagination.Page, pagination.PageSize,
                config: null, cancellationToken);
        }

        public async Task<ArticleCategoryEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var articleCategory = await _repository.GetByIdAsync(id);
            return articleCategory;
        }
    }
}
