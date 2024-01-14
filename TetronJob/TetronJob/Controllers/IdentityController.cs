using Framework.ViewModels.City;
using Framework.ViewModels.Province;
using Framework.ViewModels.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TetronJob.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IMediator _mediator;

        public IdentityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> SignUp()
        {
            await Provinces();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>
            SignUpStepOne([FromBody] InsertUserViewModel model)
        {
            var result = await _mediator.Send(model);
            return Json(result);
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
    }
}
