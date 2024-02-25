using Framework.CQRS.Query.Admin.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TetronJob.Component
{
    public class UserImageComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public UserImageComponent(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IViewComponentResult> InvokeAsync(Guid id)
        {
            var model = await _mediator.Send(new GetUserImageQuery()
            {
                Id = id
            });
            return View("/Views/Shared/ViewComponent/UserImageSection.cshtml", model);
        }
    }
}
