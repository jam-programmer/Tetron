using Application.Models;
using Framework.CQRS.Query.Article;
using Framework.CQRS.Query.ArticleCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TetronJob.Controllers
{
    public class BlogController : Controller
    {
        private readonly IMediator _mediator;

        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> BlogCategory()
        {
            var model = await _mediator.Send(new GetArticleCategoriesQuery());
            return View(model);
        }

     
        [HttpGet]
        public async Task<IActionResult> Blogs([FromQuery] PaginatedSearchWithSize options,Guid id,string name)
        {
            GetArticleOfCategoryQuery request = new GetArticleOfCategoryQuery()
            {
                Paginated = options,Id = id
            };
            var paginated = await _mediator.Send(request);
            ViewBag.Name = name;
            ViewBag.Parent = id;
            return View(paginated);
        }

        [HttpGet]
        public async Task<IActionResult> BlogDetail(Guid id)
        {
            var model = await _mediator.Send(new GetArticleByIdQuery()
            {
                Id = id
            });
            return View(model);
        }
    }
}
