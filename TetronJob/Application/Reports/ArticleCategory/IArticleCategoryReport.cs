using Application.Models;
using Domain.Entities;

namespace Application.Reports.ArticleCategory
{
    public interface IArticleCategoryReport
    {
        Task<PaginatedList<TDestination>> GetAllPaginatedAsync<TDestination>(PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default);
        Task<ArticleCategoryEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
