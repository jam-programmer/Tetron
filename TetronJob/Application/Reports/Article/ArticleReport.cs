using Application.Extensions;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Reports.Article
{
    public class ArticleReport : IArticleReport
    {
        private readonly IEfRepository<ArticleEntity> _repository;

        public ArticleReport(IEfRepository<ArticleEntity> repository)
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
                    .Where(r => r.ArticleTitle!.Contains(pagination.Keyword))
                    .AsQueryable();
            }

            return await query.PaginatedListAsync<ArticleEntity, TDestination>(pagination.Page, pagination.PageSize,
                config: null, cancellationToken);
        }

        public async Task<ArticleEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var article = await _repository.GetByQueryAsync();
            article =  article.Include(i => i.Category);
            return (await article.SingleOrDefaultAsync(s => s.Id == id))!;
        } 

        public async Task<PaginatedList<TDestination>> GetAllPaginatedAsync<TDestination>(PaginatedSearchWithSize pagination, Guid categoryId,
            CancellationToken cancellationToken = default)
        {
            var query = await _repository.GetByQueryAsync();
            query = query.Where(w => w.ArticleCategoryId == categoryId).Include(i=>i.Category);
            // Apply search filter.
            if (!string.IsNullOrEmpty(pagination.Keyword))
            {
                query = query
                    .Where(r => r.ArticleTitle!.Contains(pagination.Keyword))
                    .AsQueryable();
            }

            return await query.PaginatedListAsync<ArticleEntity, TDestination>(pagination.Page, pagination.PageSize,
                config: null, cancellationToken);
        }
    }
}
