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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category){
            if (!ModelState.IsValid) {
                return View();
            }
            AppDbContext.Categories.Add(category);
            AppDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var category= AppDbContext.Categories.FirstOrDefault(y => y.Id == id);
            if(category == null)
            {
                RedirectToAction("Index");
            }
            return View();

        }
        [HttpPost]
        public IActionResult Update(Category category)
        {
            var oldCategory = AppDbContext.Categories.FirstOrDefault(x=>x.Id == category.Id);
            if (oldCategory == null)
            {
                RedirectToAction("Index");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            oldCategory.Name= category.Name;
            AppDbContext.SaveChanges();
            return RedirectToAction("index");
          
        }
    }
}
