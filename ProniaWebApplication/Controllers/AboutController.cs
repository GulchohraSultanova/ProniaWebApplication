using Microsoft.AspNetCore.Mvc;

namespace ProniaWebApplication.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
