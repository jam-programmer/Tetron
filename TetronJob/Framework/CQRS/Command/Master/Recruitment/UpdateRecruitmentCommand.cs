using Application.Models;
using FluentValidation;
using Framework.Common;
using Framework.Factories.Recruitment;
using Framework.Factories.Sender;
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
        private readonly ISenderFactory _senderFactory;

        public UpdateRecruitmentCommandHandler(IRecruitmentFactory recruitmentFactory, ISenderFactory senderFactory)
        {
            _recruitmentFactory = recruitmentFactory;
            _senderFactory = senderFactory;
        }

        public async Task<Response> Handle(UpdateRecruitmentCommand request, CancellationToken cancellationToken)
        {
            var result= await _recruitmentFactory.UpdateRecruitmentAsync(request, cancellationToken);
            if (result.IsSuccess == true)
            {
                Dictionary<string, string>? data = (Dictionary<string, string>)result.Data!;
                if (request.Condition == ConditionViewMode.منتشرشد)
                {
                    var name = data["Name"];
                    var number = data["PhoneNumber"];
                    await _senderFactory.Accept(name, number);
                }
                if (request.Condition == ConditionViewMode.ردشد)
                {
                    var name = data["Name"];
                    var number = data["PhoneNumber"];
                    await _senderFactory.Cancel(name, number);
                }
            }
            return result;
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
