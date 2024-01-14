using Framework.ViewModels.Skill;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TetronJob.Controllers
{
    public class AdvertisingController : Controller
    {
        private readonly IMediator _mediator;

        public AdvertisingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> RequestIntroduction()
        {
            await Skills();
            return View();
        }
        [HttpGet]
        public IActionResult RequestPlacement()
        {
            return View();
        }



        [HttpGet]
        public IActionResult RequestRecruitment()
        {
            return View();
        }







        public async Task Skills()
        {
            var list = await _mediator.Send(new RequestGetSkills());
            ViewBag.list = new SelectList(list, "Id", "SkillName");
        }
    }
}
