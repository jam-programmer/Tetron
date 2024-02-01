using Application.Models;
using Framework.CQRS.Command.Master.Introduction;
using Framework.CQRS.Command.Master.Placement;
using Framework.CQRS.Query.Admin.User;
using Framework.CQRS.Query.Introduction;
using Framework.CQRS.Query.Placement;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TetronJob.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PlacementController : Controller
    {
        private readonly IMediator _mediator;

        public PlacementController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] PaginatedSearchWithSize options)
        {
            GetPlacementsQuery request = new GetPlacementsQuery()
            {
                Paginated = options
            };
            var paginated = await _mediator.Send(request);
            return View(paginated);
        }

        public async Task Users()
        {
            var list = await _mediator.Send(new GetSelectListOfUserQuery());
            ViewBag.Users = new SelectList(list, "Id", "FullName");
        }



        public async Task<IActionResult> Create()
        {
            await Users();

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(InsertPlacementCommand model, CancellationToken cancellation)
        {
            await Users();
           
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
            var result = await _mediator.Send(new GetPlacementByIdQuery()
            {
                Id = id
            });
            await Users();
  
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdatePlacementCommand model,
            CancellationToken cancellation)
        {


            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(model, cancellation);
                if (result.IsSuccess == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                await Users();
            
                ViewBag.Alert = result.Message!;
                return View(model);
            }
            await Users();
         
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeletePlacementCommand() { Id = id }, cancellationToken);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest();
        }








    }
}
