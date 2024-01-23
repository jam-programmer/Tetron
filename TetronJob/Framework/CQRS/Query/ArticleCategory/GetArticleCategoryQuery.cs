using Application.Models;
using Framework.Factories.ArticleCategory;
using MediatR;

namespace Framework.CQRS.Query.ArticleCategory
{
    public class GetArticleCategoryQuery:IRequest<PaginatedList<ArticleCategoryViewModel>>
    {
        public PaginatedSearchWithSize? Paginated { set; get; }
    }


    public class GetArticleCategoryQueryHandler : IRequestHandler<GetArticleCategoryQuery, PaginatedList<ArticleCategoryViewModel>>
    {

        private readonly IArticleCategoryFactory _articleCategory;

        public GetArticleCategoryQueryHandler(IArticleCategoryFactory articleCategory)
        {
            _articleCategory = articleCategory;
        }
        public async Task<PaginatedList<ArticleCategoryViewModel>> Handle(GetArticleCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _articleCategory.GetPagedSearchWithSizeAsync<ArticleCategoryViewModel>(request.Paginated,cancellationToken);
        }
    }
    public class ArticleCategoryViewModel
    {
        public string ArticleCategoryTitle { set; get; }
        public Guid Id { set; get; }
    }
}
