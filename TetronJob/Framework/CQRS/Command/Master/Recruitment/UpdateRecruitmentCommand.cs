using Application.Models;
using FluentValidation;
using Framework.Common;
using Framework.Factories.Recruitment;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Framework.CQRS.Command.Master.Recruitment
{
    public class UpdateRecruitmentCommand : IRequest<Response>
    {
        public ConditionViewMode Condition { set; get; } = ConditionViewMode.درانتظارتائید;
        public string? RecruitmentType { set; get; }
        public string? RecruitmentPhoneNumber { set; get; }
        public string? RecruitmentAddress { set; get; }
        public string? RecruitmentDescription { set; get; }
        public string? RecruitmentTitle { set; get; }
        public IFormFile? RecruitmentImageFile { set; get; }
        public string? RecruitmentImage { set; get; }
        public Guid UserId { set; get; }
        public Guid Id { set; get; }
    }


    public class UpdateRecruitmentCommandHandler : IRequestHandler<UpdateRecruitmentCommand, Response>
    {
        private readonly IRecruitmentFactory _recruitmentFactory;

        public UpdateRecruitmentCommandHandler(IRecruitmentFactory recruitmentFactory)
        {
            _recruitmentFactory = recruitmentFactory;
        }

        public async Task<Response> Handle(UpdateRecruitmentCommand request, CancellationToken cancellationToken)
        {
            return await _recruitmentFactory.UpdateRecruitmentAsync(request, cancellationToken);
        }
    }
    public class UpdateRecruitmentValidation : BaseValidator<UpdateRecruitmentCommand>
    {
        public UpdateRecruitmentValidation()
        {
            RuleFor(f => f.RecruitmentTitle).NotNull()
                .NotEmpty().WithMessage("عنوان آگهی الزامی است.");

            RuleFor(f => f.RecruitmentType).NotNull()
                .NotEmpty().WithMessage("نوع آگهی الزامی است.");

            RuleFor(f => f.RecruitmentAddress).NotNull()
                .NotEmpty().WithMessage("نشانی آگهی الزامی است.");

        }
    }

}
