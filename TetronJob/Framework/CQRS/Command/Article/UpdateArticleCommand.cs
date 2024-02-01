using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Framework.Factories.Article;
using MediatR;
using FluentValidation;
using Framework.Common;

namespace Framework.CQRS.Command.Article
{
    public class UpdateArticleValidation : BaseValidator<UpdateArticleCommand>
    {
        public UpdateArticleValidation()
        {

            RuleFor(f => f.ArticleTitle).NotNull().NotEmpty()
                .WithMessage("عنوان نمیتواند خالی باشد.");
            RuleFor(f => f.ArticleBody).NotNull().NotEmpty()
                .WithMessage("متن نمیتواند خالی باشد.");
        }
    }
    public class UpdateArticleCommand:IRequest<Response>
    {
        public string ArticleTitle { set; get; }
        public IFormFile? File { set; get; }
        public string ArticleBody { set; get; }
        public string ArticleTags { set; get; }
        public Guid ArticleCategoryId { set; get; }
        public string ArticleImage { set; get; }
        public Guid Id { set; get; }
    }

    public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, Response>
    {
        private readonly IArticleFactory _articleFactory;

        public UpdateArticleCommandHandler(IArticleFactory articleFactory)
        {
            _articleFactory = articleFactory;
        }
        public async Task<Response> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            return await _articleFactory.UpdateArticleAsync(request, cancellationToken);
        }

    }
}
