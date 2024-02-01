using Application.Models;
using Framework.CQRS.Command.Admin.ArticleCategory;
using Framework.CQRS.Command.Article;
using Framework.CQRS.Query.Admin.Category;
using Framework.CQRS.Query.Article;
using Framework.CQRS.Query.ArticleCategory;
using Framework.ViewModels.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TetronJob.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IMediator _mediator;

        public ArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] PaginatedSearchWithSize options)
        {
            GetArticlesQuery request = new GetArticlesQuery()
            {
                Paginated = options
            };
            var paginated = await _mediator.Send(request);
            return View(paginated);
        }


        public async Task Categories(Guid ? id)
        {
            var categories = await _mediator.Send(new GetSelectListCategoryArticleQuery());

            ViewBag.Category = id == Guid.Empty ? new SelectList(categories, "Id", "ArticleCategoryTitle") : new SelectList(categories, "Id", "ArticleCategoryTitle",id);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
          await Categories(Guid.Empty);
          return View();
        }




        [HttpPost]
        public async Task<IActionResult> Create(InsertArticleCommand model, CancellationToken cancellation)
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

            await Categories(model.ArticleCategoryId); return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new GetArticleByIdQuery()
            {
                Id = id
            });

            await Categories(result.ArticleCategoryId);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateArticleCommand model, CancellationToken cancellation)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(model, cancellation);
                if (result.IsSuccess == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Alert = result.Message!;
           
            }
            await Categories(model.ArticleCategoryId);
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(Guid id,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteArticleCommand() { Id = id }, cancellationToken);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest();
        }

    }
}
