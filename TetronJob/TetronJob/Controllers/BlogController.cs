using Microsoft.AspNetCore.Mvc;

namespace TetronJob.Controllers
{
    public class BlogController : Controller
    {
        [HttpGet]
        public IActionResult BlogCategory()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Blogs()
        {
            return View();
        }
    }
}
