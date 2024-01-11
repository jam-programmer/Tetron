using Application.Models;
using Framework.ViewModels.Category;

namespace Framework.Factories.Category
{
    public interface ICategoryFactory
    {
        Task<PaginatedList<TViewModel>> GetPagedSearchWithSizeAsync<TViewModel>
        (PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default);

        Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync();

        Task<Response> InsertCategoryAsync(InsertCategoryViewModel viewModel, CancellationToken cancellation);
        Task<Response> UpdateCategoryAsync(UpdateCategoryViewModel viewModel, CancellationToken cancellation);
        Task<Response> DeleteCategoryAsync(DeleteCategoryViewModel viewModel, CancellationToken cancellation);
        Task<UpdateCategoryViewModel> GetCategoryByIdAsync(RequestGetCategoryById request, CancellationToken cancellation);
    }
}
