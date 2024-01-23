using Application.Models;
using Framework.CQRS.Command.Article;
using Framework.CQRS.Query.Article;

namespace Framework.Factories.Article
{
    public interface IArticleFactory
    {
        Task<PaginatedList<TViewModel>> GetPagedSearchWithSizeAsync<TViewModel>
        (PaginatedSearchWithSize pagination,
            CancellationToken cancellationToken = default);

        Task<Response> InsertArticleAsync(InsertArticleCommand command, CancellationToken cancellation);
        Task<Response> UpdateArticleAsync(UpdateArticleCommand command, CancellationToken cancellation);
        Task<Response> DeleteArticleAsync(DeleteArticleCommand command, CancellationToken cancellation);
        Task<UpdateArticleCommand> GetArticleByIdAsync(GetArticleByIdQuery request, CancellationToken cancellation);
    }
}
