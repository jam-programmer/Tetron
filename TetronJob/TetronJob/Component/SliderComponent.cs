using Domain.Enums;
using Framework.CQRS.Query.Admin.Category;
using Framework.CQRS.Query.Slider;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TetronJob.Component
{
    public class SliderComponent:ViewComponent
    {
        private readonly IMediator _mediator;

        public SliderComponent(IMediator mediator)
        {
            _mediator = mediator;
        }


        public async Task<IViewComponentResult> InvokeAsync(PositionEnum position)
        {
            var model = await _mediator.Send(new GetSlidesWithPositionQuery()
            {
                Position = position
            });
            return View("/Views/Shared/ViewComponent/SliderSection.cshtml", model);
        }
    }
}
