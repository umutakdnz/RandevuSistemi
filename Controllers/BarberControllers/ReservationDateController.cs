using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandevuSistemi.Models.AdminSiniflar;
using System.Globalization;

namespace RandevuSistemi.Controllers.BarberControllers
{
    [Authorize(AuthenticationSchemes = "BarberScheme")]
    public class ReservationDateController : Controller
    {
        private readonly Context db;

        public ReservationDateController(Context context)
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
            return 0;
        }

        public async Task<IActionResult> Index()
        {
            var currentBarberId = GetCurrentUserBarberId();

            await RemovePastReservationDates(currentBarberId);
            await RemoveUnavailableReservationDates(currentBarberId);
            await GenerateReservationDates(currentBarberId, 10);

            var today = DateTime.Today;

            var values = await db.ReservationsDate
                .Include(r => r.ReservationHour)
                .ThenInclude(h => h.ReservationDays)
                .Where(r => r.Date >= today && r.BarberID == currentBarberId)
                .OrderBy(r => r.Date)
                .ThenBy(r => r.Time)
                .ToListAsync();

            return View(values);
        }

        private async Task RemovePastReservationDates(int barberId)
        {
            var today = DateTime.Today;

            var oldDates = await db.ReservationsDate
                .Where(r => r.Date < today && r.BarberID == barberId)
                .ToListAsync();

            if (oldDates.Any())
            {
                db.ReservationsDate.RemoveRange(oldDates);
                await db.SaveChangesAsync();
            }
        }

        private async Task RemoveUnavailableReservationDates(int barberId)
        {
            var unavailableHourIds = await db.ReservationHours
                .Where(h => !h.IsAvailable && h.BarberID == barberId)
                .Select(h => h.ReservationHoursID)
                .ToListAsync();

            var toDeleteDates = await db.ReservationsDate
                .Where(rd => unavailableHourIds.Contains(rd.ReservationHourId) && rd.BarberID == barberId)
                .ToListAsync();

            if (toDeleteDates.Any())
            {
                db.ReservationsDate.RemoveRange(toDeleteDates);
                await db.SaveChangesAsync();
            }
        }

        public async Task GenerateReservationDates(int barberId, int dayCount = 20)
        {
            var startDate = DateTime.Today;
            var endDate = startDate.AddDays(dayCount);

            var allHourTemplates = await db.ReservationHours
                .Include(h => h.ReservationDays)
                .Where(h => h.IsAvailable && h.BarberID == barberId)
                .ToListAsync();

            for (var date = startDate; date < endDate; date = date.AddDays(1))
            {
                var dayName = date.ToString("dddd", new CultureInfo("tr-TR"));

                var dayHours = allHourTemplates
                    .Where(h => h.ReservationDays != null &&
                                h.ReservationDays.DayName.Equals(dayName, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                foreach (var hour in dayHours)
                {
                    bool exists = await db.ReservationsDate
                        .AnyAsync(rd => rd.Date == date && rd.Time == hour.TimeSlot && rd.BarberID == barberId);

                    if (!exists)
                    {
                        var newReservationDate = new ReservationDate
                        {
                            Date = date,
                            DayName = dayName,
                            Time = hour.TimeSlot,
                            ReservationHourId = hour.ReservationHoursID,
                            IsAvailable = true,
                            BarberID = barberId
                        };

                        db.ReservationsDate.Add(newReservationDate);
                    }
                }
            }

            await db.SaveChangesAsync();
        }

        [HttpGet]
        public IActionResult UpdateReservationDate(int id)
        {
            var currentBarberId = GetCurrentUserBarberId();
            var values = db.ReservationsDate.FirstOrDefault(r => r.ReservationDateID == id && r.BarberID == currentBarberId);
            if (values == null) return NotFound();
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateReservationDate(ReservationDate model)
        {
            var currentBarberId = GetCurrentUserBarberId();
            var values = db.ReservationsDate.FirstOrDefault(r => r.ReservationDateID == model.ReservationDateID && r.BarberID == currentBarberId);
            if (values == null) return NotFound();

            values.IsAvailable = model.IsAvailable;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
