using Application.Models;
using Framework.CQRS.Command.Admin.ArticleCategory;
using Framework.CQRS.Query.ArticleCategory;


namespace Framework.Factories.ArticleCategory
{
    public interface IArticleCategoryFactory
    {
        Task<PaginatedList<TViewModel>> GetPagedSearchWithSizeAsync<TViewModel>
        (PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default);
        Task<Response> InsertArticleCategoryAsync(InsertArticleCategoryCommand command, CancellationToken cancellation);
        Task<Response> UpdateArticleCategoryAsync(UpdateArticleCategoryCommand command, CancellationToken cancellation);
        Task<Response> DeleteArticleCategoryAsync(DeleteArticleCategoryCommand command, CancellationToken cancellation);
        Task<UpdateArticleCategoryCommand> GetCategoryByIdAsync
            (GetArticleCategoryByIdQuery request, CancellationToken cancellation);


        Task<List<CategoryBox>> GetCategoriesBox();

        Task<List<ArticleCategoryViewModel>> GetSelectListOfArticleCategoriesAsync(CancellationToken cancellation);

    }
}
