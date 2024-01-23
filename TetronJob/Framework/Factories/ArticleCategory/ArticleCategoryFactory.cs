using Application.Models;
using Application.Reports.ArticleCategory;
using Application.Services.ArticleCategory;
using Domain.Entities;
using Framework.Common.Application.Core;
using Framework.CQRS.Command.Admin.ArticleCategory;
using Framework.CQRS.Query.ArticleCategory;
using Framework.ViewModels.Category;
using Mapster;

namespace Framework.Factories.ArticleCategory
{
    public class ArticleCategoryFactory: IArticleCategoryFactory
    {

        private readonly IArticleCategoryReport _articleCategoryReport;
        private readonly IArticleCategoryService _articleCategoryService;

        public ArticleCategoryFactory(IArticleCategoryReport articleCategoryReport, IArticleCategoryService articleCategoryService)
        {
            _articleCategoryReport = articleCategoryReport;
            _articleCategoryService = articleCategoryService;
        }
        public async Task<Response> InsertArticleCategoryAsync(InsertArticleCategoryCommand command, CancellationToken cancellation)
        {
            ArticleCategoryEntity category = command.Adapt<ArticleCategoryEntity>();
                    return await _articleCategoryService.InsertAsync(category, cancellation);
        }

        public async Task<Response> UpdateArticleCategoryAsync(UpdateArticleCategoryCommand command, CancellationToken cancellation)
        {
            var category = await _articleCategoryReport.GetByIdAsync(command.Id, cancellation);
            category = command.Adapt<ArticleCategoryEntity>();
            return await _articleCategoryService.UpdateAsync(category, cancellation);
        }

        public async Task<Response> DeleteArticleCategoryAsync(DeleteArticleCategoryCommand command, CancellationToken cancellation)
        {
            var category = await _articleCategoryReport.GetByIdAsync(command.Id, cancellation);
            var result = await _articleCategoryService.DeleteAsync(category, cancellation);
            return Response.Succeded();
        }

        public async Task<UpdateArticleCategoryCommand> GetCategoryByIdAsync(GetArticleCategoryByIdQuery request, CancellationToken cancellation)
        {
            var category = await _articleCategoryReport.GetByIdAsync(request.Id, cancellation);
            UpdateArticleCategoryCommand updateCategory = category.Adapt<UpdateArticleCategoryCommand>();
           
            return updateCategory;
        }

        public async Task<PaginatedList<TViewModel>> GetPagedSearchWithSizeAsync<TViewModel>(PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default)
        {
            return await _articleCategoryReport.GetAllPaginatedAsync<TViewModel>(pagination, cancellationToken);
        }
    }
}
