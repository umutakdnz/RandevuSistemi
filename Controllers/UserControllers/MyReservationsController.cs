using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RandevuSistemi.Models.AdminSiniflar;

namespace RandevuSistemi.Controllers.UserControllers
{
    public class MyReservationsController : Controller
    {
        private readonly Context db;
        public MyReservationsController(Context context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var values = db.Reserveds.Include(r => r.Barber).ToList();
            return View(values);
        }

        public IActionResult DeleteMyReservations(int id)
        {
            var values = db.Reserveds.Find(id);
            db.Reserveds.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateMyReservations(int id)
        {
            var values = db.Reserveds.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateMyReservations(Reserved model)
        {
            var values = db.Reserveds.Find(model.ReservedID);
            values.Date = model.Date;
            values.Time = model.Time;
            values.Barber = model.Barber;
            values.Description = model.Description;
            values.Situation = model.Situation;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
