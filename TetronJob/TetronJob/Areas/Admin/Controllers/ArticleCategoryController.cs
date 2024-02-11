using Application.Models;
using Framework.CQRS.Command.Admin.ArticleCategory;
using Framework.CQRS.Query.ArticleCategory;
using Framework.ViewModels.Category;
using Framework.ViewModels.Skill;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TetronJob.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ArticleCategoryController : Controller
    {
        private readonly IMediator _mediator;

        public ArticleCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] PaginatedSearchWithSize options)
        {
            GetArticleCategoryQuery request = new GetArticleCategoryQuery()
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
        public async Task<IActionResult> Create(InsertArticleCategoryCommand model, CancellationToken cancellation)
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
            var result = await _mediator.Send(new GetArticleCategoryByIdQuery()
            {
                Id = id
            });

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateArticleCategoryCommand model, CancellationToken cancellation)
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
            var result = await _mediator.Send(new DeleteArticleCategoryCommand() { Id = id }, cancellationToken);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest();
        }


    }
}
