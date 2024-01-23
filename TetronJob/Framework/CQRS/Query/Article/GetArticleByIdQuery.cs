using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.CQRS.Command.Article;
using Framework.Factories.Article;
using MediatR;

namespace Framework.CQRS.Query.Article
{
    public class GetArticleByIdQuery:IRequest<UpdateArticleCommand>
    {
        public Guid Id { get; set; }
    }

    public class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, UpdateArticleCommand>
    {
        private readonly IArticleFactory _articleFactory;

        public GetArticleByIdQueryHandler(IArticleFactory articleFactory)
        {
            _articleFactory = articleFactory;
        }
        public async Task<UpdateArticleCommand> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
        {
            return await _articleFactory.GetArticleByIdAsync(request, cancellationToken);
        }
    }
}
