using Application.Models;
using Framework.ViewModels.Role;
using Framework.ViewModels.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading;
using Framework.ViewModels.Category;
using Framework.ViewModels.City;
using Framework.ViewModels.Province;
using Microsoft.AspNetCore.Authorization;

namespace TetronJob.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] PaginatedSearchWithSize options)
        {
            RequestUsers request = new RequestUsers()
            {
                Paginated = options
            };

            var paginated = await _mediator.Send(request);

            return View(paginated);

        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await Roles();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(InsertUserViewModel model, CancellationToken cancellation)
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
            await Roles(model.RoleId);
            return View(model);
        }

        [HttpGet]

        public async Task<IActionResult> Edit([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new RequestGetUserById()
            {
                Id = id
            });
            await Roles(result.RoleId);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateUserViewModel model, CancellationToken cancellation)
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
            await Roles(model.RoleId);
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(Guid id,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteUserViewModel() { Id = id }, cancellationToken);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest();
        }


        [HttpGet]
        public async Task<IActionResult> SetAddress(Guid id)
        {
            var result = await _mediator.Send(new SetUserAddressViewModel()
            {
                UserId = id,
                Get = true,
                CityId = Guid.Empty,
                ProvinceId = Guid.Empty
            });
            await Provinces(result.ProvinceId);
            await SelectCities(result.ProvinceId);

            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> SetAddress(SetUserAddressViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new SetUserAddressViewModel()
                {
                    UserId = model.UserId,
                    Get = false,
                    CityId = model.CityId,
                    ProvinceId = model.ProvinceId
                });
                return RedirectToAction(nameof(Index));
            }

            await Provinces(model.ProvinceId); await SelectCities(model.ProvinceId);
            return View(model);
        }
        public async Task Provinces(Guid? id = null)
        {
            var result = await _mediator.Send(new RequestGetProvinces());
            ViewBag.Provinces = new SelectList(result, "Id", "Name", id);
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
        public async Task SelectCities(Guid id)
        {
            var result = await _mediator.Send(new RequestGetCities()
            {
                Id = id
            });
            ViewBag.SelectCities = new SelectList(result, "Id", "Name", id);
        }


        [HttpGet]
        public async Task<IActionResult> SetCategories(Guid id)
        {
            ViewBag.User = id;
            var result = await _mediator.Send(new UserCategoryViewModel
            {
                UserId = id,
                Get = true
            });
            await Categories();
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> SetCategories(UserCategoryViewModel model)
        {
            var result = await _mediator.Send(new UserCategoryViewModel
            {
                UserId = model.UserId
                ,CategoryIds = model.CategoryIds,
                Get = false
            });
            return RedirectToAction(nameof(Index));
        }

        public async Task Categories()
        {
            var result = await _mediator.Send(new RequestGetCategories());
            ViewBag.Categories = result;
        }

        public async Task Roles(Guid? id = null)
        {
            var result = await _mediator.Send(new RequestSelectedRoles());
            ViewBag.Roles = new SelectList(result, "Id", "PersianName", id);
        }
    }
}
