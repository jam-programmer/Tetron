using Application.Models;
using Framework.ViewModels.City;
using Framework.ViewModels.Province;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TetronJob.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CityController : Controller
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] PaginatedSearchWithSize options,Guid id)
        {
            RequestCities request = new RequestCities()
            {
                Paginated = options,Id = id
            };

            var paginated = await _mediator.Send(request);
            ViewBag.Province = id;
            return View(paginated);
        }
        [HttpGet]
        public IActionResult Create(Guid id)
        {
            ViewBag.Province = id;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(InsertCityViewModel model, CancellationToken cancellation)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(model, cancellation);
                if (result.IsSuccess == true)
                {
                    return RedirectToAction(nameof(Index),new{id=model.ProvinceId});
                }
                ViewBag.Alert = result.Message!;
                return View(model);
            }
            ViewBag.Province = model.ProvinceId;
            return View(model);
        }



        [HttpGet]

        public async Task<IActionResult> Edit([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new RequestGetCityById()
            {
                Id = id
            });

            return View(result);
        }






        [HttpPost]
        public async Task<IActionResult> Edit(UpdateCityViewModel model, CancellationToken cancellation)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(model, cancellation);
                if (result.IsSuccess == true)
                {
                    return RedirectToAction(nameof(Index), new { id = model.ProvinceId });
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
            var result = await _mediator.Send(new DeleteCityViewModel() { Id = id }, cancellationToken);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest();
        }







    }
}
