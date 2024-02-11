using System.Security.Claims;
using Framework.CQRS.Query.Admin.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TetronJob.Controllers
{
    [Authorize]
    
    public class ProfileController : Controller
    {
        private readonly IMediator _mediator;

        public ProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public string? UserId()
        {
            return User!.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public IActionResult Dashboard()
        {
            ViewBag.User = Guid.Parse(UserId());
            return View();
        }
    }
}
