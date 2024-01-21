using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TetronJob.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
      
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
