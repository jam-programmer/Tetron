using Application.Models;
using FluentValidation;
using Framework.Common;
using Framework.Factories.Identity.User;
using Framework.Factories.Recruitment;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Framework.CQRS.Command.Master.Recruitment
{
    public class InsertRecruitmentCommand:IRequest<Response>
    {
        public ConditionViewMode Condition { set; get; } = ConditionViewMode.درانتظارتائید;
        public string? RecruitmentType { set; get; }
        public string? RecruitmentPhoneNumber { set; get; }
        public string? RecruitmentAddress { set; get; }
        public string? RecruitmentDescription { set; get; }
        public string? RecruitmentTitle { set; get; }
        public IFormFile? RecruitmentImage { set; get; }
        public Guid UserId { set; get; }
        public List<IFormFile>? Gallery { set; get; } = new();
    }

    public class InsertRecruitmentValidation : BaseValidator<InsertRecruitmentCommand>
    {
        public InsertRecruitmentValidation()
        {
            RuleFor(f => f.RecruitmentTitle).NotNull()
                .NotEmpty().WithMessage("عنوان آگهی الزامی است.");

            RuleFor(f => f.RecruitmentType).NotNull()
                .NotEmpty().WithMessage("نوع آگهی الزامی است.");

            RuleFor(f => f.RecruitmentAddress).NotNull()
                .NotEmpty().WithMessage("نشانی آگهی الزامی است.");

        }
    }


    public class InsertRecruitmentCommandHandler : IRequestHandler<InsertRecruitmentCommand, Response>
    {
        private readonly IRecruitmentFactory _recruitmentFactory;

        public InsertRecruitmentCommandHandler(IRecruitmentFactory recruitmentFactory)
        {
            _recruitmentFactory = recruitmentFactory;
        }
        public async Task<Response> Handle(InsertRecruitmentCommand request, CancellationToken cancellationToken)
        {
            return await _recruitmentFactory.InsertRecruitmentAsync(request, cancellationToken);
        }
    }
}
