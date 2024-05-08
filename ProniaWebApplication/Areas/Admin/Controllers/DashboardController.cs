using Microsoft.AspNetCore.Mvc;

namespace ProniaWebApplication.Areas.ProniaAdmin.Controllers
{
    public class DashboardController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
