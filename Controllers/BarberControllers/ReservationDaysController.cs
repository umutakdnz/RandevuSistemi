using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RandevuSistemi.Models.AdminSiniflar;
using System.Linq;

namespace RandevuSistemi.Controllers.BarberControllers
{
    [Authorize(AuthenticationSchemes = "BarberScheme")]
    public class ReservationDaysController : Controller
    {
        private readonly Context db;
        public ReservationDaysController(Context context)
        {
            db = context;
        }

        private int GetCurrentUserBarberId()
        {
            var barberIdClaim = User.Claims.FirstOrDefault(c => c.Type == "BarberID");
            if (barberIdClaim != null && int.TryParse(barberIdClaim.Value, out int barberId))
            {
                return barberId;
            }
            return 0; // veya uygun bir varsayılan
        }

        public IActionResult Index()
        {
            var currentBarberId = GetCurrentUserBarberId();
            var values = db.ReservationsDays
                           .Where(rd => rd.BarberId == currentBarberId)
                           .ToList();
            return View(values);
        }

        public IActionResult DeleteReservationDays(int id)
        {
            var currentBarberId = GetCurrentUserBarberId();
            var values = db.ReservationsDays.FirstOrDefault(rd => rd.ReservationDaysID == id && rd.BarberId == currentBarberId);
            if (values != null)
            {
                db.ReservationsDays.Remove(values);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateReservationDays(int id)
        {
            var currentBarberId = GetCurrentUserBarberId();
            var values = db.ReservationsDays.FirstOrDefault(rd => rd.ReservationDaysID == id && rd.BarberId == currentBarberId);
            if (values == null)
            {
                return NotFound();
            }
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateReservationDays(ReservationDays model)
        {
            var currentBarberId = GetCurrentUserBarberId();
            var values = db.ReservationsDays.FirstOrDefault(rd => rd.ReservationDaysID == model.ReservationDaysID && rd.BarberId == currentBarberId);
            if (values == null)
            {
                return NotFound();
            }

            values.DayName = model.DayName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateReservationDays()
        {
            ViewBag.BarberId = GetCurrentUserBarberId();
            return View();
        }

        [HttpPost]
        public IActionResult CreateReservationDays(ReservationDays model)
        {
            try
            {
                ModelState.Clear();

                if (string.IsNullOrWhiteSpace(model.DayName))
                {
                    ModelState.AddModelError("DayName", "Gün adı zorunludur.");
                    ViewBag.BarberId = GetCurrentUserBarberId();
                    return View(model);
                }

                var newReservationDay = new ReservationDays
                {
                    DayName = model.DayName?.Trim(),
                    BarberId = GetCurrentUserBarberId()
                };

                db.ReservationsDays.Add(newReservationDay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Hata: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Inner Exception: {ex.InnerException?.Message}");

                ModelState.AddModelError("", "Bir hata oluştu. Lütfen tekrar deneyin.");
                ViewBag.BarberId = GetCurrentUserBarberId();
                return View(model);
            }
        }
    }
}
