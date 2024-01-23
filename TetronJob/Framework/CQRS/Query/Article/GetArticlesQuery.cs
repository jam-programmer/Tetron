using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Factories.Article;
using MediatR;

namespace Framework.CQRS.Query.Article
{
    public class GetArticlesQuery:IRequest<PaginatedList<ArticleViewModel>>
    {
        public PaginatedSearchWithSize? Paginated { set; get; }
    }

    public class GetArticlesQueryHandler : IRequestHandler<GetArticlesQuery, PaginatedList<ArticleViewModel>>
    {
        private readonly IArticleFactory _articleFactory;

        public GetArticlesQueryHandler(IArticleFactory articleFactory)
        {
            _articleFactory = articleFactory;
        }
        public async Task<PaginatedList<ArticleViewModel>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
        {
            return await _articleFactory.GetPagedSearchWithSizeAsync<ArticleViewModel>(request.Paginated,
                cancellationToken);
        }
    }
    public class ArticleViewModel
    {
        public Guid Id { get; set; }
        public string ArticleTitle { set; get; }
        public string ArticleImage { set; get; }
        public int VisitCount { set; get; }
    }
}
