using Microsoft.AspNetCore.Mvc;
using RandevuSistemi.Models.AdminSiniflar;

namespace RandevuSistemi.Controllers.AdminControllers
{
    public class BarberController : Controller
    {
        private readonly Context db;

        public BarberController(Context context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var values = db.Barbers.ToList();
            return View(values);
        }

        public IActionResult DeleteBarber(int id)
        {
            var values = db.Barbers.Find(id);
            db.Barbers.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateBarber()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBarber(Barber barber)
        {
            db.Barbers.Add(barber);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateBarber(int id)
        {
            var values = db.Barbers.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateBarber(Barber model)
        {
            var values = db.Barbers.Find(model.BarberId);
            values.BarberName = model.BarberName;
            values.BarberNumber = model.BarberNumber;
            values.BarberDescription = model.BarberDescription;
            values.Expertise = model.Expertise;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
