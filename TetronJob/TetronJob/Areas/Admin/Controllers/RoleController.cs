using Application.Models;
using Framework.ViewModels.Role;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TetronJob.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(InsertRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(model);
                if (result.IsSuccess == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Alert = result.Message!;
                return View(model);
            }
           
            return View(model);
        }

        [HttpGet]
        [Route("/Admin/Role/Edit")]
        public async Task<IActionResult> Edit(Guid id,CancellationToken cancellation)
        {
            var result = await _mediator.Send(new RequestGetRoleById()
            {
                RoleId = id
            });
            return View(result);
        }
        [HttpPost]
        [Route("/Admin/Role/Edit")]
        public async Task<IActionResult> Edit(UpdateRoleViewModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(model, cancellationToken);
                if (result.IsSuccess == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Alert = result.Message!;
                return View(model);
            }

            return View(model);
        }
        [HttpGet]
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteRoleViewModel() { Id = id },cancellationToken);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest();
        }

     
    }
}
