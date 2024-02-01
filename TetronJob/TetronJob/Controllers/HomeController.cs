using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Framework.CQRS.Command.Contact;
using Framework.CQRS.Query.Setting;
using MediatR;
using TetronJob.Models;

namespace TetronJob.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Route("Help")]
        public async Task<IActionResult> Help()
        {
            var model = await _mediator.Send(new GetHelpQuery());
            return View(model);
        }

        [Route("Law")]
        public async Task<IActionResult> Law()
        {
            var model = await _mediator.Send(new GetLawQuery());
            return View(model);
        }
        [Route("About")]
        public async Task<IActionResult> About()
        {
            var model = await _mediator.Send(new GetAboutQuery());
            return View(model);
        }


        [Route("ContactUs")]
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        [Route("ContactUs")]
        public async Task<IActionResult> ContactUs([FromForm] InsertContactCommand command)
        {

            var result = await _mediator.Send(command);
            return Json(result);
        }
    }
}