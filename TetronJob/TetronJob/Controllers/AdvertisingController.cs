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
using Framework.CQRS.Query.Admin.User;
using Framework.CQRS.Query.Introduction;
using Framework.CQRS.Query.Placement;
using Framework.CQRS.Query.Recruitment;

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
            command.UserId = Guid.Parse(UserId()!);
            var result = await _mediator.Send(command);
            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> RequestPlacement([FromForm] InsertPlacementCommand command)
        {
            command.UserId = Guid.Parse(UserId()!);
            var result = await _mediator.Send(command);
            return Json(result);
        }


        [HttpPost]
        public async Task<IActionResult> RequestIntroduction([FromForm] InsertIntroductionCommand command)
        {
            command.UserId = Guid.Parse(UserId()!);
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

        [HttpGet]
        public async Task<IActionResult> CategoryUser
            (Guid id, Guid CityId, Guid ProvinceId, string search = "")
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

        [HttpGet]
        public async Task<IActionResult> Introduction(Guid CityId, Guid ProvinceId, string search = "")
        {
            await Provinces();
            var result = await _mediator.Send(new GetIntroductionWithFilterQuery()
            {
                Filter = new Filter()
                {
                    CityId = CityId,
                    ProvinceId = ProvinceId,
                    Search = search
                }
            });
            return View(result);
        }


        [HttpGet]
        public async Task<IActionResult> Placement(Guid CityId, Guid ProvinceId, string search = "")
        {
            await Provinces();
            var result = await _mediator.Send(new GetPlacementWithFilterQuery()
            {
                Filter = new Filter()
                {
                    CityId = CityId,
                    ProvinceId = ProvinceId,
                    Search = search
                }
            });
            return View(result);
        }



        [HttpGet]
        public async Task<IActionResult> Recruitment(Guid CityId, Guid ProvinceId, string search = "")
        {
            await Provinces();
            var result = await _mediator.Send(new GetRecruitmentWithFilterQuery()
            {
                Filter = new Filter()
                {
                    CityId = CityId,
                    ProvinceId = ProvinceId,
                    Search = search
                }
            });
            return View(result);
        }


        [HttpGet]
        public async Task<IActionResult> UserDetail(Guid id)
        {

            var model = await _mediator.Send(new GetUserCategoryByIdQuery()
            {
                Id = id
            });
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> PlacementDetail(Guid id)
        {
            var model = await _mediator.Send(new GetPlacementDetailQuery()
            {
                Id = id
            });
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> IntroductionDetail(Guid id)
        {
            var model = await _mediator.Send(new GetIntroductionDetailQuery()
            {
                Id = id
            });
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> RecruitmentDetail(Guid id)
        {
            var model = await _mediator.Send(new GetRecruitmentDetailQuery()
            {
                Id = id
            });
            return View(model);
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
