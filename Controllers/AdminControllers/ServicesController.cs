using Microsoft.AspNetCore.Mvc;
using RandevuSistemi.Models.AdminSiniflar;

namespace RandevuSistemi.Controllers.AdminControllers
{
    public class ServicesController : Controller
    {
        private readonly Context db;

        public ServicesController(Context context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var values = db.Services.ToList();
            return View(values);
        }

        public IActionResult DeleteServices(int id)
        {
            var values= db.Services.Find(id);
            db.Services.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }

        [HttpGet]
        public IActionResult CreateServices()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateServices(Services services)
        {
            db.Services.Add(services);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateServices(int id)
        {
            var values = db.Services.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateServices(Services model)
        {
            var values = db.Services.Find(model.ServicesID);
            values.Description = model.Description;
            values.Title = model.Title;
            values.IconUrl = model.IconUrl;
            values.Description2 = model.Description2;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
