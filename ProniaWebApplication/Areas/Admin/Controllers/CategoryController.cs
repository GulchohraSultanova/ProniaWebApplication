using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaWebApplication.DAL;
using ProniaWebApplication.Models;

namespace ProniaWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
     
        AppDbContext AppDbContext;

        public CategoryController(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            List<Category> categories = AppDbContext.Categories.Include(x => x.Products).ToList();
            return View(categories);
        }
        public IActionResult Delete(int id)
        {
            var category=AppDbContext.Categories.FirstOrDefault(x => x.Id == id);
            AppDbContext.Remove(category);
            AppDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
