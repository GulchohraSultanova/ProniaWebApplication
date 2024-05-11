using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaWebApplication.DAL;
using ProniaWebApplication.Models;
using ProniaWebApplication.ViewModel;
using System.Diagnostics;

namespace ProniaWebApplication.Controllers
{
    public class HomeController : Controller
    {
        
        AppDbContext AppDbContext { get; set; }

        public HomeController(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }

        public  IActionResult Index()

        {
            List<Product> products = AppDbContext.Products.Include(x => x.Photos).Where(x => x.Photos.Count() > 0).ToList();
            HomeVm vm = new HomeVm()
            {
               Products = products,
               Sliders=AppDbContext.Sliders.ToList(),
            };
            return View(vm);
        }

        
    }
}
