using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.Factories.ArticleCategory;
using MediatR;

namespace Framework.CQRS.Command.Admin.ArticleCategory
{
    public class DeleteArticleCategoryCommand:IRequest<Response>
    {
        public Guid Id { get; set; }
    }

    public class DeleteArticleCategoryCommandHandler : IRequestHandler<DeleteArticleCategoryCommand, Response>
    {
        private readonly IArticleCategoryFactory _articleCategoryFactory;

        public DeleteArticleCategoryCommandHandler(IArticleCategoryFactory articleCategoryFactory)
        {
            _articleCategoryFactory = articleCategoryFactory;
        }
        public async Task<Response> 
            Handle(DeleteArticleCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _articleCategoryFactory.DeleteArticleCategoryAsync(request, cancellationToken);
        }
    }
}
