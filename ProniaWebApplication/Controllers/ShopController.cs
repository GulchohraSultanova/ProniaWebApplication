using Microsoft.AspNetCore.Mvc;

namespace ProniaWebApplication.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShopGrid()
        {
            return View();
        }
        public IActionResult ShopList()
        {
            return View();
        }
        public IActionResult ShopListLeft()
        {
            return View();
        }
        public IActionResult ShopListRight()
        {
            return View();
        }
        public IActionResult ShopRight()
        {
            return View();
        }
    }
}
