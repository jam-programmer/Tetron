using Domain.Enums;
using Framework.CQRS.Query.Admin.User;
using Framework.CQRS.Query.Slider;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TetronJob.Component
{
    public class UserPanelComponent:ViewComponent
    {
        private readonly IMediator _mediator;

        public UserPanelComponent(IMediator mediator)
        {
            _mediator = mediator;
        }


        public async Task<IViewComponentResult> InvokeAsync(Guid id)
        {
            var model = await _mediator.Send(new GetUserCategoryByIdQuery()
            {
                Id = id
            });
            return View("/Views/Shared/ViewComponent/UserPanelSection.cshtml", model);
        }
    }
}
