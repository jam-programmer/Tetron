using Application.Models;
using Framework.ViewModels.Role;
using Framework.ViewModels.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading;

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
        public async Task<IActionResult> Index([FromQuery] PaginatedSearchWithSize options)
        {
            RequestUsers request = new RequestUsers()
            {
                Paginated = options
            };

            var paginatedRoles = await _mediator.Send(request);

            return View(paginatedRoles);

        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await Roles();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(InsertUserViewModel model,CancellationToken cancellation)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(model, cancellation);
                if (result.IsSuccess == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Alert = result.Message!;
                return View(model);
            }
            await Roles(model.RoleId);
            return View(model);
        }

        [HttpGet]
        
        public async Task<IActionResult> Edit([FromRoute]  Guid id)
        {
            var result = await _mediator.Send(new RequestGetUserById()
            {
                Id = id
            });
            await Roles(result.RoleId);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateUserViewModel model, CancellationToken cancellation)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(model, cancellation);
                if (result.IsSuccess == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Alert = result.Message!;
                return View(model);
            }
            await Roles(model.RoleId);
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(Guid id,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteUserViewModel() { Id = id }, cancellationToken);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest();
        }



        public async Task Roles(Guid? id = null)
        {
            var result = await _mediator.Send(new RequestSelectedRoles());
            ViewBag.Roles = new SelectList(result, "Id", "PersianName", id);
        }
    }
}
