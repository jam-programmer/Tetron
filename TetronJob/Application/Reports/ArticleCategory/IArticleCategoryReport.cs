using Application.Models;
using Domain.Entities;

namespace Application.Reports.ArticleCategory
{
    public interface IArticleCategoryReport
    {
        Task<PaginatedList<TDestination>> GetAllPaginatedAsync<TDestination>(PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default);
        Task<ArticleCategoryEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);


        Task<List<ArticleCategoryEntity>> GetArticleCategories(CancellationToken cancellationToken = default);


        Task<List<ArticleCategoryEntity>>GetCategories(CancellationToken cancellationToken = default);
    }
}
