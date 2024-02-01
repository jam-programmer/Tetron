using Framework.CQRS.Query.Admin.Category;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TetronJob.Component
{
    public class MenuCategoryComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public MenuCategoryComponent(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _mediator.Send(new GetCategoryHomeQuery());
            return View("/Views/Shared/ViewComponent/MenuCategorySection.cshtml", model);
        }
    }
}
