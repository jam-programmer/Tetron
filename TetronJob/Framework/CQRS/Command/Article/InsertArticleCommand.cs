using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using FluentValidation;
using Framework.Common;
using Framework.CQRS.Command.Admin.ArticleCategory;
using Framework.Factories.Article;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Framework.CQRS.Command.Article
{
    public class InsertArticleCommand:IRequest<Response>
    {
        public string ArticleTitle { set; get; }
        public IFormFile ArticleImage { set; get; }
        public string ArticleBody { set; get; }
        public string ArticleTags { set; get; }
        public Guid ArticleCategoryId { set; get; }
    }

    public class InsertArticleCommandHandler : IRequestHandler<InsertArticleCommand, Response>
    {
        private readonly IArticleFactory _articleFactory;

        public InsertArticleCommandHandler(IArticleFactory articleFactory)
        {
            _articleFactory = articleFactory;
        }
        public async Task<Response> Handle(InsertArticleCommand request, CancellationToken cancellationToken)
        {
            return await _articleFactory.InsertArticleAsync(request, cancellationToken);
        }
    }
    public class InsertArticleValidation : BaseValidator<InsertArticleCommand>
    {
        public InsertArticleValidation()
        {

            RuleFor(f => f.ArticleTitle).NotNull().NotEmpty()
                .WithMessage("عنوان نمیتواند خالی باشد.");
            RuleFor(f => f.ArticleBody).NotNull().NotEmpty()
                .WithMessage("متن نمیتواند خالی باشد.");
        }
    }

}
