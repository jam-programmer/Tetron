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
    public class UpdateArticleCategoryCommand:IRequest<Response>
    {
        public Guid Id { get; set; }
        public string ArticleCategoryTitle { set; get; }
    }

    public class UpdateArticleCategoryValidation : BaseValidator<UpdateArticleCategoryCommand>
    {
        public UpdateArticleCategoryValidation()
        {
            RuleFor(f => f.ArticleCategoryTitle).NotNull()
                .NotEmpty().WithMessage("نام دسته بندی را وارد کنید.");
        }
    }
    public class UpdateArticleCategoryCommandHandler : IRequestHandler<UpdateArticleCategoryCommand, Response>
    {
        private readonly IArticleCategoryFactory _articleCategoryFactory;

        public UpdateArticleCategoryCommandHandler(IArticleCategoryFactory articleCategoryFactory)
        {
            _articleCategoryFactory = articleCategoryFactory;
        }
        public async Task<Response> Handle(UpdateArticleCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _articleCategoryFactory.UpdateArticleCategoryAsync(request, cancellationToken);
        }
    }

}
