using Application.Models;
using Framework.CQRS.Command.Master.Introduction;
using Framework.CQRS.Query.Admin.User;
using Framework.CQRS.Query.Article;
using Framework.CQRS.Query.Introduction;
using Framework.ViewModels.Skill;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TetronJob.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class IntroductionController : Controller
    {
        private readonly IMediator _mediator;

        public IntroductionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] PaginatedSearchWithSize options)
        {
            GetIntroductionsQuery request = new GetIntroductionsQuery()
            {
                Paginated = options
            };
            var paginated = await _mediator.Send(request);
            return View(paginated);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await Users();
            await Skills();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(InsertIntroductionCommand model, CancellationToken cancellation)
        {
            await Users();
            await Skills();
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
            var result = await _mediator.Send(new GetIntroductionByIdQuery()
            {
                Id = id
            });
            await Users();
            await Skills();
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateIntroductionCommand model,
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
                await Skills();
                ViewBag.Alert = result.Message!;
                return View(model);
            }
            await Users();
            await Skills();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteIntroductionCommand() { Id = id }, cancellationToken);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest();
        }

        [HttpPost]
        public void Change([FromBody]ChangeIntroductionCommand command)
        {
             _mediator.Send(command);
        }



        public async Task Users()
        {
            var list = await _mediator.Send(new GetSelectListOfUserQuery());
            ViewBag.Users = new SelectList(list, "Id", "FullName");
        }


        public async Task Skills()
        {
            var list = await _mediator.Send(new RequestGetSkills());
            ViewBag.list = list;
        }



    }
}
