using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandevuSistemi.Models.AdminSiniflar;

namespace RandevuSistemi.Controllers.BarberControllers
{
    [Authorize(AuthenticationSchemes = "BarberScheme")]
    public class AppointmentsController : Controller
    {
        private readonly Context db;
        public AppointmentsController(Context _context)
        {
            db = _context;
        }
        //public IActionResult Index()
        //{
        //    var values = db.Reserveds.Include(r => r.Barber).Include(r => r.ReservationHours).ToList();
        //    return View(values);
        //}

        public IActionResult Index()
        {
            var barberID = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "BarberID").Value);

            var values = db.Reserveds.Include(r => r.Barber).Include(r => r.ReservationHours).Where(r => r.BarberID == barberID).ToList();

            return View(values);
        }

    }
}
