using Application.Models;
using Framework.CQRS.Query.Contact;
using Framework.CQRS.Query.Introduction;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TetronJob.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] PaginatedSearchWithSize options)
        {
            GetContactsQuery request = new GetContactsQuery(){
                Paginated = options
            };
            var paginated = await _mediator.Send(request);
            return View(paginated);
        }
    }
}
