using Microsoft.AspNetCore.Mvc;

namespace ProniaWebApplication.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListView()
        {
            return View();
        }
        public IActionResult Detail()
        {
            return View();
        }

    }
}
