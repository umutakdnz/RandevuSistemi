using Microsoft.AspNetCore.Mvc;
using RandevuSistemi.Models.AdminSiniflar;

namespace RandevuSistemi.Controllers.AdminControllers
{
    public class AboutController : Controller
    {
        private readonly Context db;

        public AboutController(Context context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var values = db.Abouts.ToList();
            return View(values);
        }

        public IActionResult DeleteAbout(int id)
        {
            var values = db.Abouts.Find(id);
            db.Abouts.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAbout(About about)
        {
            db.Abouts.Add(about);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var values = db.Abouts.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateAbout(About model)
        {
            var values = db.Abouts.Find(model.AboutID);
            values.ImgUrl = model.ImgUrl;
            values .Title = model.Title;
            values .Description = model.Description;
            values.FoundedYear = model.FoundedYear;
            values.Address = model.Address;
            values.Phone = model.Phone;
            values.Email = model.Email;
            values.Person = model.Person;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
