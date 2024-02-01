using Application.Models;
using Framework.CQRS.Command.Slider;
using Framework.CQRS.Query.Slider;
using Framework.ViewModels.Skill;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TetronJob.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly IMediator _mediator;

        public SliderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] PaginatedWithSize options)
        {
            GetSlidesQuery request = new GetSlidesQuery()
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
        public async Task<IActionResult> Create(InsertSliderCommand model, CancellationToken cancellation)
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
            var result = await _mediator.Send(new GetSlideByIdQuery()
            {
                Id = id
            });

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateSliderCommand model, CancellationToken cancellation)
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
            var result = await _mediator.Send(new DeleteSliderCommand() { Id = id }, cancellationToken);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest();
        }



    }
}
