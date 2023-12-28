using Application.Models;
using Framework.ViewModels.Role;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TetronJob.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] PaginatedWithSize options)
        {
            RequestRoles request = new RequestRoles()
            {
                Paginated = options
            };

            var paginatedRoles = await _mediator.Send(request);

            return View(paginatedRoles);

        }

    }
}
