using Application.Models;
using FluentValidation;
using Framework.Common;
using Framework.Factories.Introduction;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Framework.CQRS.Command.Master.Introduction
{
    public class InsertIntroductionCommandHandler : IRequestHandler<InsertIntroductionCommand, Response>
    {
        private readonly IIntroductionFactory _introductionFactory;

        public InsertIntroductionCommandHandler(IIntroductionFactory introductionFactory)
        {
            _introductionFactory = introductionFactory;
        }
        public async Task<Response> Handle(InsertIntroductionCommand request, CancellationToken cancellationToken)
        {
            return await _introductionFactory.InsertIntroductionAsync(request, cancellationToken);
        }
    }
    public class InsertIntroductionCommand : IRequest<Response>
    {
        public ConditionViewMode Condition { set; get; } = ConditionViewMode.درانتظارتائید;
        public List<IFormFile>? Gallery { set; get; } = new();
        public Guid UserId { set; get; }
        public string? IntroductionPhoneNumber { set; get; }
        public string? IntroductionTitle { set; get; }
        public IFormFile? IntroductionImage { set; get; }
        public string? IntroductionDescription { set; get; }
        public List<Guid> Skills { set; get; } = new List<Guid>();

    }

    public class InsertIntroductionValidation : BaseValidator<InsertIntroductionCommand>
    {
        public InsertIntroductionValidation()
        {
            RuleFor(f => f.IntroductionTitle).NotNull().NotEmpty().WithMessage("عنوان الزامی است.");
            RuleFor(f => f.IntroductionPhoneNumber).NotNull().NotEmpty().WithMessage("شماره تماس الزامی است.");
            RuleFor(f => f.UserId).NotNull().NotEmpty().WithMessage("انتخاب منتشر کننده الزامی است.");
        }
    }
}
