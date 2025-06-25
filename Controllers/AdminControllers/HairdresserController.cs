using Microsoft.AspNetCore.Mvc;
using RandevuSistemi.Models.AdminSiniflar;

namespace RandevuSistemi.Controllers.AdminControllers
{
    public class HairdresserController : Controller
    {
        private readonly Context db;

        public HairdresserController(Context context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var values = db.Hairdressers.ToList();
            return View(values);
        }

        public IActionResult DeleteHairdresser(int id)
        {
            var values = db.Hairdressers.Find(id);
            db.Hairdressers.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateHairdresser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateHairdresser(Hairdresser hairdresser)
        {
            db.Hairdressers.Add(hairdresser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateHairdresser(int id)
        {
            var values = db.Hairdressers.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateHairdresser(Hairdresser model)
        {
            var values = db.Hairdressers.Find(model.HairdresserID);
            values.Name = model.Name;
            values.Email = model.Email;
            values.Password = model.Password;
            values.Phone = model.Phone;
            values.Role = model.Role;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
