using Application.Models;
using Domain.Entities;

namespace Application.Services.Category
{
    public interface ICategoryService
    {
        
        Task<Response> InsertAsync(CategoryEntity category, CancellationToken cancellationToken);
        Task<Response> UpdateAsync(CategoryEntity category, CancellationToken cancellationToken);
        Task<Response> DeleteAsync(CategoryEntity category, CancellationToken cancellationToken);

    }
}
