using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaWebApplication.DAL;
using ProniaWebApplication.Models;

namespace ProniaWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagController : Controller
    {
        AppDbContext _db;

        public TagController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Tag> tags=_db.Tags.Include(x=>x.Products).ToList();
            return View(tags);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Tag tag)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _db.Tags.Add(tag);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var tag =_db.Tags.FirstOrDefault(x => x.Id == id);
            _db.Remove(tag);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var tag =_db.Tags.FirstOrDefault(y => y.Id == id);
            if(tag == null)
            {
                RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Update(Tag tag) {
            var oldtag = _db.Tags.FirstOrDefault(y=>y.Id == tag.Id);
            if (oldtag == null)
            {
               RedirectToAction("Index");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
           oldtag.Name=tag.Name;
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
