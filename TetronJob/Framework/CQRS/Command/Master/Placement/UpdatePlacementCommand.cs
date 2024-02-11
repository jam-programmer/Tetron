using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using FluentValidation;
using Framework.Common;
using Framework.Factories.Placement;
using Framework.Factories.Sender;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Framework.CQRS.Command.Master.Placement
{
    public class UpdatePlacementCommand:IRequest<Response>
    {
        public ConditionViewMode Condition { set; get; } = ConditionViewMode.درانتظارتائید;
        public string? PlacementFullName { set; get; }
        public string? PlacementNumber { set; get; }
        public string? PlacementDescription { set; get; }
        public IFormFile? PlacementImageFile { set; get; }
        public string? PlacementImage { set; get; }
        public Guid? UserId { set; get; }
        public Guid Id { set; get; }
    }

    public class UpdatePlacementCommandHandler : IRequestHandler<UpdatePlacementCommand, Response>
    {
        private readonly IPlacementFactory _placementFactory;
        private readonly ISenderFactory _senderFactory;

        public UpdatePlacementCommandHandler(IPlacementFactory placementFactory, ISenderFactory senderFactory)
        {
            _placementFactory = placementFactory;
            _senderFactory = senderFactory;
        }
        public async Task<Response> Handle(UpdatePlacementCommand request, CancellationToken cancellationToken)
        {
            var result= await _placementFactory.UpdatePlacementAsync(request, cancellationToken);
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

    public class UpdatePlacementValidation : BaseValidator<UpdatePlacementCommand>
    {
        public UpdatePlacementValidation()
        {
            RuleFor(f => f.PlacementFullName).NotNull()
                .NotEmpty().WithMessage("وارد کردن نام الزامی است.");


            RuleFor(f => f.PlacementNumber).NotNull()
                .NotEmpty().WithMessage("وارد کردن شماره الزامی است.");
        }
    }

}
