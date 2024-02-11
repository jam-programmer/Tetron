using Framework.CQRS.Command.Setting;
using Framework.CQRS.Query.Setting;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TetronJob.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SettingController : Controller
    {
        private readonly  IMediator _mediator;

        public SettingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/Admin/Setting")]
        public async Task<IActionResult> Setting()
        {
          
            var result=await _mediator.Send(new GetSettingQuery());
            return View(result);
        } 
        [HttpPost]
        [Route("/Admin/Setting")]
        public async Task<IActionResult> Setting(ChangeSetting? setting)
        {

            var result = await _mediator.Send(setting!);
         
            return RedirectToAction(nameof(Setting));
        }
    }
}
