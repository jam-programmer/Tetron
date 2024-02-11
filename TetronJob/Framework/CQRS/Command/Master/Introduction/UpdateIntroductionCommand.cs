using Application.Models;
using Domain.Enums;
using FluentValidation;
using Framework.Common;
using Framework.Factories.Introduction;
using Framework.Factories.Sender;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Framework.CQRS.Command.Master.Introduction
{
    public class UpdateIntroductionValidation : BaseValidator<UpdateIntroductionCommand>
    {
        public UpdateIntroductionValidation()
        {
            RuleFor(f => f.IntroductionTitle).NotNull().NotEmpty().WithMessage("عنوان الزامی است.");
            RuleFor(f => f.IntroductionPhoneNumber).NotNull().NotEmpty().WithMessage("شماره تماس الزامی است.");
            RuleFor(f => f.UserId).NotNull().NotEmpty().WithMessage("انتخاب منتشر کننده الزامی است.");
        }
    }
    public class UpdateIntroductionCommand : IRequest<Response>
    {
        public Guid Id { set; get; }
        public Guid UserId { set; get; }
        public string? IntroductionPhoneNumber { set; get; }
        public string? IntroductionTitle { set; get; }
        public IFormFile? IntroductionImageFile { set; get; }
        public string? IntroductionImage { set; get; }
        public string? IntroductionDescription { set; get; }
        public List<Guid?> Skills { set; get; } 
        public ConditionViewMode Condition { set; get; }
    }

    public class UpdateIntroductionCommandHandler : IRequestHandler<UpdateIntroductionCommand, Response>
    {
        private readonly IIntroductionFactory _introductionFactory;
        private readonly ISenderFactory _senderFactory;

        public UpdateIntroductionCommandHandler(IIntroductionFactory introductionFactory, ISenderFactory senderFactory)
        {
            _introductionFactory = introductionFactory;
            _senderFactory = senderFactory;
        }
        public async Task<Response> Handle(UpdateIntroductionCommand request, CancellationToken cancellationToken)
        {
            var result= await _introductionFactory.UpdateIntroductionAsync(request, cancellationToken);
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
}
