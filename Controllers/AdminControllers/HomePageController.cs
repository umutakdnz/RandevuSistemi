using Microsoft.AspNetCore.Mvc;
using RandevuSistemi.Models.AdminSiniflar;

namespace RandevuSistemi.Controllers.AdminControllers
{
    public class HomePageController : Controller
    {
        private readonly Context db;

        public HomePageController(Context context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var values = db.HomePages.ToList();
            return View(values);
        }

        public IActionResult DeleteHomePage(int id)
        {
            var values = db.HomePages.Find(id);
            db.HomePages.Remove(values);
            db.SaveChanges();   
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateHomePage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateHomePage(HomePage homePage)
        {
            db.HomePages.Add(homePage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateHomePage(int id)
        {
            var values = db.HomePages.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateHomePage(HomePage model)
        {
            var values = db.HomePages.Find(model.HomePageID);
            values.NameSurname = model.NameSurname;
            values.Description = model.Description;
            values.ImageUrl = model.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
