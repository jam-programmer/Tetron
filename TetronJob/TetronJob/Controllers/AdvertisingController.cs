using Framework.CQRS.Command.Master.Introduction;
using Framework.CQRS.Command.Master.Placement;
using Framework.CQRS.Command.Master.Recruitment;
using Framework.ViewModels.Category;
using Framework.ViewModels.City;
using Framework.ViewModels.Province;
using Framework.ViewModels.Skill;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Framework.CQRS.Query.Admin.Category;

namespace TetronJob.Controllers
{
    public class AdvertisingController : Controller
    {
        private readonly IMediator _mediator;

        #region Insert

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

        [HttpPost]
        public async Task<IActionResult> RequestRecruitment([FromForm] InsertRecruitmentCommand command)
        {
            command.UserId=Guid.Parse(UserId()!);
            var result = await _mediator.Send(command);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> RequestPlacement([FromForm] InsertPlacementCommand command)
        {
            command.UserId=Guid.Parse(UserId()!);
            var result = await _mediator.Send(command);
            return Json(result);
        }


        [HttpPost]
        public async Task<IActionResult> RequestIntroduction([FromForm] InsertIntroductionCommand command)
        {
            command.UserId=Guid.Parse(UserId()!);
            var result = await _mediator.Send(command);
            return Json(result);
        }


        public string? UserId()
        {
            return User!.FindFirstValue(ClaimTypes.NameIdentifier);
        }


        public async Task Skills()
        {
            var list = await _mediator.Send(new RequestGetSkills());
            ViewBag.list = new SelectList(list, "Id", "SkillName");
        }


        #endregion





        #region Show
        [Route("/8")]
        [HttpGet]
        public async Task<IActionResult> CategoryUser
            (Guid id,Guid CityId,Guid ProvinceId,string search="")
        {
            ViewBag.Id = id;
            var model = await _mediator.Send(new CategoryFilter()
            {
                ProvinceId = ProvinceId,
                CategoryId = id,
                CityId = CityId,
                Search = search
            });
            await Provinces();
            return View(model.Users);
        }
       





        public async Task Provinces()
        {
            var result = await _mediator.Send(new RequestGetProvinces());
            ViewBag.Provinces = new SelectList(result, "Id", "Name");
        }
        [HttpGet]
        public async Task<JsonResult> Cities(Guid id)
        {
            var result = await _mediator.Send(new RequestGetCities()
            {
                Id = id
            });
            return Json(result);
        }
        #endregion
    }
}
