
using Application.Models;
using Application.Reports.Article;
using Application.Reports.ArticleCategory;
using Application.Services.Article;
using Domain.Entities;
using Framework.Common.Application.Core;
using Framework.CQRS.Command.Article;
using Framework.CQRS.Query.Article;
using Framework.ViewModels.Category;
using Mapster;

namespace Framework.Factories.Article
{
    public class ArticleFactory:IArticleFactory
    {
        private readonly IArticleReport _report;
        private readonly IArticleService _service;

        public ArticleFactory(IArticleReport report, IArticleService service)
        {
            _report = report;
            _service = service;
        }
        public async Task<PaginatedList<TViewModel>> GetPagedSearchWithSizeAsync<TViewModel>(PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default)
        {
            return await _report.GetAllPaginatedAsync<TViewModel>(pagination, cancellationToken);
        }

        public async Task<Response> InsertArticleAsync(InsertArticleCommand command, CancellationToken cancellation)
        {
            ArticleEntity article = command.Adapt<ArticleEntity>();
            article.ArticleImage = FileProcessing.FileUpload(command.ArticleImage, null, "ArticleImage");
            return await _service.InsertAsync(article, cancellation);
        }

        public async Task<Response> UpdateArticleAsync(UpdateArticleCommand command, CancellationToken cancellation)
        {
            var article = await _report.GetByIdAsync(command.Id, cancellation);
            article = command.Adapt<ArticleEntity>();
            article.ArticleImage = FileProcessing.FileUpload(command.ArticleImage, command.Path, "CategoryImage");
            return await _service.UpdateAsync(article, cancellation);
        }

        public async Task<Response> DeleteArticleAsync(DeleteArticleCommand command, CancellationToken cancellation)
        {
            var article = await _report.GetByIdAsync(command.Id, cancellation);
            var result = await _service.DeleteAsync(article, cancellation);
            if (result.IsSuccess == true)
            {
                FileProcessing.RemoveFile(article.ArticleImage!, "CategoryImage");
            }

            return result;
        }

        public async Task<UpdateArticleCommand> GetArticleByIdAsync(GetArticleByIdQuery request, CancellationToken cancellation)
        {
            var article = await _report.GetByIdAsync(request.Id, cancellation);
            UpdateArticleCommand updateArticle = article.Adapt<UpdateArticleCommand>();
            updateArticle.Path = article.ArticleImage;
            return updateArticle;
        }
    }
}
