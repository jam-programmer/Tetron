using Application.Models;
using Domain.Entities;

namespace Application.Reports.Category
{
    public interface ICategoryReport
    {
        Task<PaginatedList<TDestination>> GetAllPaginatedAsync<TDestination>(PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default);
        Task<CategoryEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<CategoryEntity>> GetAllCategoriesAsync();


    }
}
