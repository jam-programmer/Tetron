using Application.Extensions;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Reports.ArticleCategory
{
    public class ArticleCategoryReport : IArticleCategoryReport
    {
        private readonly IEfRepository<ArticleCategoryEntity> _repository;

        public ArticleCategoryReport(IEfRepository<ArticleCategoryEntity> repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedList<TDestination>> GetAllPaginatedAsync<TDestination>(
            PaginatedSearchWithSize pagination,
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

            return await query.PaginatedListAsync<ArticleCategoryEntity, TDestination>(pagination.Page,
                pagination.PageSize,
                config: null, cancellationToken);
        }

        public async Task<ArticleCategoryEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var articleCategory = await _repository.GetByIdAsync(id);
            return articleCategory;
        }

        public async Task<List<ArticleCategoryEntity>> GetArticleCategories(
            CancellationToken cancellationToken = default)
        {
            var query = await _repository.GetByQueryAsync();
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<List<ArticleCategoryEntity>> GetCategories(CancellationToken cancellationToken = default)
        {
            var query = await _repository.GetByQueryAsync();
            var result = query.Select(s => new ArticleCategoryEntity
            {
                ArticleCategoryTitle = s.ArticleCategoryTitle,
                Id = s.Id,
                Article = s.Article.Take(5).OrderByDescending(d=>d.CreateTime).Select(a => new ArticleEntity
                {
                    Id = a.Id,
                    ArticleTitle = a.ArticleTitle
                }).ToList()
            }).ToList();
            return result;
        }

    }
}
