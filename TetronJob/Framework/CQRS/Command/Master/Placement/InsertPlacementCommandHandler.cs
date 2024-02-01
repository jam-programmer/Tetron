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
    public class InsertPlacementCommand : IRequest<Response>
    {
        public ConditionViewMode Condition { set; get; } = ConditionViewMode.درانتظارتائید;
        public string? PlacementFullName { set; get; }
        public string? PlacementNumber { set; get; }
        public string? PlacementDescription { set; get; }
        public IFormFile? PlacementImage { set; get; }
        public Guid? UserId { set; get; }
        public List<IFormFile>? Gallery { set; get; } = new();
    }

    public class InsertPlacementValidation : BaseValidator<InsertPlacementCommand>
    {
        public InsertPlacementValidation()
        {
            RuleFor(f => f.PlacementFullName).NotNull()
                .NotEmpty().WithMessage("وارد کردن نام الزامی است."); 
            
            
            RuleFor(f => f.PlacementNumber).NotNull()
                .NotEmpty().WithMessage("وارد کردن شماره الزامی است.");
        }
    }

    public class InsertPlacementCommandHandler:IRequestHandler<InsertPlacementCommand,Response>
    {
        private readonly IPlacementFactory _placementFactory;

        public InsertPlacementCommandHandler(IPlacementFactory placementFactory)
        {
            _placementFactory = placementFactory;
        }
        public async Task<Response> Handle(InsertPlacementCommand request, CancellationToken cancellationToken)
        {
            return await _placementFactory.InsertPlacementAsync(request, cancellationToken);
        }
    }
}
