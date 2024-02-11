using Framework.CQRS.Query.Admin.Category;
using Framework.CQRS.Query.Setting;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TetronJob.Component
{
    public class SocialComponent:ViewComponent
    {
        private readonly IMediator _mediator;

        public SocialComponent(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _mediator.Send(new GetSocialQuery());
            return View("/Views/Shared/ViewComponent/SocialSection.cshtml", model);
        }
    }
}
