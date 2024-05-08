using Microsoft.AspNetCore.Mvc;

namespace ProniaWebApplication.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult Faq()
        {
            return View();
        }
        public IActionResult Error404()
        {
            return View();
        }

    }
}
