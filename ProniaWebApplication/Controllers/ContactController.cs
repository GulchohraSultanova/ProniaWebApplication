using Microsoft.AspNetCore.Mvc;

namespace ProniaWebApplication.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
