using Microsoft.AspNetCore.Mvc;

namespace TetronJob.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
