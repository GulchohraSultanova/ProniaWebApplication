using Microsoft.AspNetCore.Mvc;

namespace ProniaWebApplication.Controllers
{
    public class RelatedController : Controller
    {
        public IActionResult Account()
        {
            return View();
        }
        public IActionResult LoginRegister()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult Wishlist()
        {
            return View();
        }
        public IActionResult Compare()
        {
            return View();
        }
        public IActionResult Checkout()
        {
            return View();
        }
    }
}
