using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.Factories.Article;
using MediatR;

namespace Framework.CQRS.Command.Article
{
    public class DeleteArticleCommand:IRequest<Response>
    {
        public Guid Id { get; set; }
    }

    public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand, Response>
    {
        private readonly IArticleFactory _articleFactory;

        public DeleteArticleCommandHandler(IArticleFactory articleFactory)
        {
            _articleFactory = articleFactory;
        }
        public async Task<Response> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            return await _articleFactory.DeleteArticleAsync(request, cancellationToken);
        }
    }
}
