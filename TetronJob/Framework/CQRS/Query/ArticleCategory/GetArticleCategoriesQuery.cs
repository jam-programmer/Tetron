using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Factories.ArticleCategory;
using MediatR;

namespace Framework.CQRS.Query.ArticleCategory
{
    public class GetArticleCategoriesQuery:IRequest<List<CategoryBox>>, IRequest<IRequest<List<CategoryBox>>>
    {
    }

    public class
        GetArticleCategoriesQueryHandler : IRequestHandler<GetArticleCategoriesQuery, List<CategoryBox>>
    {
        private readonly IArticleCategoryFactory _articleCategoryFactory;

        public GetArticleCategoriesQueryHandler(IArticleCategoryFactory articleCategoryFactory)
        {
            _articleCategoryFactory = articleCategoryFactory;
        }
        public async Task<List<CategoryBox>> Handle(GetArticleCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _articleCategoryFactory.GetCategoriesBox();
        }
    }
    public class CategoryBox
    {
        public Guid Id { get; set; }
        public string ArticleCategoryTitle { set; get; }
        public List<ArticleItem> Article { set;get; }
    }

    public class ArticleItem
    {
        public Guid Id { get; set; }
        public string ArticleTitle { set; get; }
    }

}
