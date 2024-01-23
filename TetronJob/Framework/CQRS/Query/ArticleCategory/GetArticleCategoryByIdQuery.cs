using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.CQRS.Command.Admin.ArticleCategory;
using Framework.Factories.ArticleCategory;
using MediatR;

namespace Framework.CQRS.Query.ArticleCategory
{
    public class GetArticleCategoryByIdQuery:IRequest<UpdateArticleCategoryCommand>
    {
        public Guid Id { get; set; }
    }

    public class
        GetArticleCategoryByIdQueryHandler : IRequestHandler<GetArticleCategoryByIdQuery, UpdateArticleCategoryCommand>
    {
        private readonly IArticleCategoryFactory _articleCategoryFactory;

        public GetArticleCategoryByIdQueryHandler(IArticleCategoryFactory articleCategoryFactory)
        {
            _articleCategoryFactory = articleCategoryFactory;
        }
        public async Task<UpdateArticleCategoryCommand> Handle(GetArticleCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _articleCategoryFactory.GetCategoryByIdAsync(request, cancellationToken);
        }
    }
}
