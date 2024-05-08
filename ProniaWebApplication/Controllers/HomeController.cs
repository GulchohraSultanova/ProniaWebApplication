using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaWebApplication.DAL;
using ProniaWebApplication.Models;
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

        public async Task<IActionResult> Index()

        {
            List<Product> products=await AppDbContext.Products.Include(x=>x.Photos).Where(x=>x.Photos.Count()>0).ToListAsync();
            return View(products);
        }

        
    }
}
