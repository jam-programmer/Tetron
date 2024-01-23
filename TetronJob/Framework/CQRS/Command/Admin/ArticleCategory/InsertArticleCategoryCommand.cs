using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using FluentValidation;
using Framework.Common;
using Framework.Factories.ArticleCategory;
using MediatR;

namespace Framework.CQRS.Command.Admin.ArticleCategory
{
    public class InsertArticleCategoryCommand:IRequest<Response>
    {
        public string ArticleCategoryTitle { set; get; }
    }

    public class InsertArticleCategoryCommandHandler : IRequestHandler<InsertArticleCategoryCommand, Response>
    {
        private readonly IArticleCategoryFactory _articleCategoryFactory;

        public InsertArticleCategoryCommandHandler(IArticleCategoryFactory articleCategoryFactory)
        {
            _articleCategoryFactory = articleCategoryFactory;
        }
        public async Task<Response> Handle(InsertArticleCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _articleCategoryFactory.InsertArticleCategoryAsync(request, cancellationToken);
        }
    }



    public class InsertArticleCategoryValidation : BaseValidator<InsertArticleCategoryCommand>
    {
        public InsertArticleCategoryValidation()
        {
            RuleFor(f => f.ArticleCategoryTitle).NotNull()
                .NotEmpty().WithMessage("نام دسته بندی را وارد کنید.");
        }
    }
}
