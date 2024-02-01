using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using FluentValidation;
using Framework.Common;
using Framework.Factories.Placement;
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

        public UpdatePlacementCommandHandler(IPlacementFactory placementFactory)
        {
            _placementFactory = placementFactory;
        }
        public async Task<Response> Handle(UpdatePlacementCommand request, CancellationToken cancellationToken)
        {
            return await _placementFactory.UpdatePlacementAsync(request, cancellationToken);
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
