using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaWebApplication.DAL;
using ProniaWebApplication.Models;

namespace ProniaWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        AppDbContext AppDbContext;


        public SliderController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            AppDbContext = appDbContext;

        }

        public IActionResult Index()
        {
            List<Slider> sliders = AppDbContext.Sliders.ToList();
            return View(sliders);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(Slider slider)
        {

            if (slider.PhotoFile == null || !slider.PhotoFile.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("PhotoFile", "Formati duzgun daxil edin");
                return View();
            }


            string filename = slider.PhotoFile.FileName;
            string path = "C:\\Users\\gulco\\OneDrive\\İş masası\\ProniaWebApplication\\ProniaWebApplication\\wwwroot\\Upload\\Slider\\";
            using (FileStream stream = new FileStream(path + filename, FileMode.Create))
            {
                slider.PhotoFile.CopyTo(stream);

            }


            slider.ImgUrl = filename;


            if (!ModelState.IsValid)
            {
                return View();
            }
            await AppDbContext.Sliders.AddAsync(slider);
            await AppDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var slider = AppDbContext.Sliders.FirstOrDefault(s => s.Id == id);
            string path = "C:\\Users\\gulco\\OneDrive\\İş masası\\ProniaWebApplication\\ProniaWebApplication\\wwwroot\\Upload\\Slider\\";

            FileInfo fileInfo = new FileInfo(path + slider.ImgUrl);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
            AppDbContext.Sliders.Remove(slider);
            AppDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int? id)
        {
            var slider = AppDbContext.Sliders.Find(id);
            if (slider == null)
            {
                RedirectToAction(nameof(Index));
            }
            return View(slider);
        }
        [HttpPost]
        public IActionResult Update(Slider slider)
        {
            var updateSlider = AppDbContext.Sliders.FirstOrDefault(x => x.Id == slider.Id);
            if (updateSlider == null)
            {
                return RedirectToAction("Index");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            updateSlider.Title = slider.Title;
            updateSlider.Description = slider.Description;
            updateSlider.Subtitle = slider.Subtitle;
            if (slider.PhotoFile != null && slider.PhotoFile.ContentType.Contains("image/"))
            {
                string filename = slider.PhotoFile.FileName;
                string path = "C:\\Users\\gulco\\OneDrive\\İş masası\\ProniaWebApplication\\ProniaWebApplication\\wwwroot\\Upload\\Slider\\";

                using (FileStream stream = new FileStream(path + filename, FileMode.Create))
                {
                    slider.PhotoFile.CopyTo(stream);
                }
              

                updateSlider.ImgUrl = filename;

            }
            AppDbContext.Update(updateSlider);
            AppDbContext.SaveChanges();
            return RedirectToAction(nameof(Index)); 

        }


    }
}
