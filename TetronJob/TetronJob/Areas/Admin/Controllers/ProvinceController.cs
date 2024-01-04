using Application.Models;
using Framework.ViewModels.Province;
using Framework.ViewModels.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TetronJob.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProvinceController : Controller
    {
        private readonly IMediator _mediator;

        public ProvinceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] PaginatedSearchWithSize options)
        {
            RequestProvinces request = new RequestProvinces()
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
        public async Task<IActionResult> Create(InsertProvinceViewModel model, CancellationToken cancellation)
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
            var result = await _mediator.Send(new RequestGetProvinceById()
            {
                Id = id
            });
           
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProvinceViewModel model, CancellationToken cancellation)
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
            var result = await _mediator.Send(new DeleteProvinceViewModel() { Id = id }, cancellationToken);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest();
        }







    }
}
