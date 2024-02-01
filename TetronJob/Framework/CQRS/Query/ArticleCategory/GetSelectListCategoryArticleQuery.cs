using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Factories.ArticleCategory;
using MediatR;

namespace Framework.CQRS.Query.ArticleCategory
{
    public class GetSelectListCategoryArticleQuery:IRequest<List<ArticleCategoryViewModel>>
    {
    }

    public class GetSelectListCategoryArticleQueryHandler :
        IRequestHandler<GetSelectListCategoryArticleQuery, List<ArticleCategoryViewModel>>
    {
        private readonly IArticleCategoryFactory _articleCategoryFactory;

        public GetSelectListCategoryArticleQueryHandler(IArticleCategoryFactory articleCategoryFactory)
        {
            _articleCategoryFactory = articleCategoryFactory;
        }
        public async Task<List<ArticleCategoryViewModel>> Handle(GetSelectListCategoryArticleQuery request, CancellationToken cancellationToken)
        {
            return await _articleCategoryFactory.GetSelectListOfArticleCategoriesAsync(cancellationToken);
        }
    }
}
