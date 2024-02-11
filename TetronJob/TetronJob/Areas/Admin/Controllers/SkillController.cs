using Application.Models;
using Framework.ViewModels.Category;
using Framework.ViewModels.Skill;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TetronJob.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SkillController : Controller
    {
        private readonly IMediator _mediator;

        public SkillController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] PaginatedWithSize options)
        {
            RequestSkills request = new RequestSkills()
            {
                Paginated = options
            };

            var paginated = await _mediator.Send(request);

            return View(paginated);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(InsertSkillViewModel model, CancellationToken cancellation)
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

            return View(model);
        }
        [HttpGet]

        public async Task<IActionResult> Edit([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new RequestGetSkillById()
            {
                Id = id
            });

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateSkillViewModel model, CancellationToken cancellation)
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

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteSkillViewModel() { Id = id }, cancellationToken);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest();
        }


    }
}
