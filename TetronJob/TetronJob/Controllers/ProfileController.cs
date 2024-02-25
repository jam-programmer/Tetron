using System.Security.Claims;
using Framework.CQRS.Command.Admin.User;
using Framework.CQRS.Query.Admin.User;
using Framework.ViewModels.User;
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

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var id = Guid.Parse(UserId());
            ViewBag.User = Guid.Parse(UserId());
            var result = await _mediator.Send(new GetProfileQuery()
            {
                Id = id
            });
 
            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> EditProfile(EditProfile model, CancellationToken cancellation)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(model, cancellation);
                if (result.IsSuccess == true)
                {
                    return RedirectToAction(nameof(Dashboard));
                }
                ViewBag.Alert = result.Message!;
                return View(model);
            }
         
            return View(model);
        }







    }
}
