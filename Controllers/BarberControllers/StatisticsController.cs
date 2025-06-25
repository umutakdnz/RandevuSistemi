using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandevuSistemi.Models.AdminSiniflar;

namespace RandevuSistemi.Controllers.BarberControllers
{
    public class StatisticsController : BaseController
    {
        private readonly Context db;
        public StatisticsController(Context context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                // Debug bilgileri
                var allClaims = User.Claims.ToList();
                ViewBag.DebugClaims = string.Join(", ", allClaims.Select(c => $"{c.Type}:{c.Value}"));

                int barberId = GetCurrentUserBarberId();

                // BarberId kontrolü
                if (barberId == 0)
                {
                    barberId = 1; // Test için - gerçek değerle değiştirin
                }

                // Berber var mı kontrol et
                var barber = await db.Barbers.FirstOrDefaultAsync(b => b.BarberId == barberId);
                if (barber == null)
                {
                    ViewBag.ErrorMessage = $"BarberId {barberId} için berber bulunamadı";
                    return View();
                }

                ViewBag.BarberName = barber.BarberName;

                // DEBUG: Veritabanında veri var mı kontrol et
                var totalReservedCount = await db.Reserveds.CountAsync();
                var totalBarbersCount = await db.Barbers.CountAsync();
                var totalReservationDatesCount = await db.ReservationsDate.CountAsync();

                ViewBag.DebugInfo = $"Toplam Reserved: {totalReservedCount}, " +
                                   $"Toplam Berberler: {totalBarbersCount}, " +
                                   $"Toplam ReservationDate: {totalReservationDatesCount}";

                var today = DateTime.Today;
                var firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
                var startOfWeek = StartOfWeek(today, DayOfWeek.Monday);

                // Ana randevu tablosu Reserved tablosu
                var allReservations = await db.Reserveds
                    .Include(r => r.Barber)
                    .Where(r => r.BarberID == barberId)
                    .ToListAsync();

                ViewBag.DebugBarberReservationsCount = allReservations.Count;

                // İstatistikler - Reserved tablosundan
                ViewBag.TotalReservations = allReservations.Count;

                ViewBag.TotalThisMonth = allReservations
                    .Where(r => r.Date.HasValue && r.Date.Value >= firstDayOfMonth && r.Date.Value <= today)
                    .Count();

                ViewBag.TotalThisWeek = allReservations
                    .Where(r => r.Date.HasValue && r.Date.Value >= startOfWeek && r.Date.Value <= today)
                    .Count();

                ViewBag.TotalToday = allReservations
                    .Where(r => r.Date.HasValue && r.Date.Value.Date == today)
                    .Count();

                // Saatlik Yoğunluk Analizi (bugün) - Reserved tablosundan
                var todayReservations = allReservations
                    .Where(r => r.Date.HasValue && r.Date.Value.Date == today && r.Time.HasValue)
                    .ToList();

                var hourlyIntensity = todayReservations
                    .GroupBy(r => r.Time.Value.Hours)
                    .Select(g => new { Hour = g.Key, Count = g.Count() })
                    .OrderBy(g => g.Hour)
                    .ToList();

                ViewBag.HourlyIntensity = hourlyIntensity;

                // En Yoğun Günler (son 30 gün) - Reserved tablosundan
                var startDate30DaysAgo = today.AddDays(-30);
                var busiestDays = allReservations
                    .Where(r => r.Date.HasValue && r.Date.Value >= startDate30DaysAgo && r.Date.Value <= today)
                    .GroupBy(r => r.Date.Value.Date)
                    .Select(g => new { Date = g.Key, Count = g.Count() })
                    .OrderByDescending(g => g.Count)
                    .Take(5)
                    .ToList();

                ViewBag.BusiestDays = busiestDays;

                // En Yoğun Saatler (son 30 gün) - Reserved tablosundan
                var busiestHours = allReservations
                    .Where(r => r.Date.HasValue && r.Date.Value >= startDate30DaysAgo && r.Date.Value <= today && r.Time.HasValue)
                    .GroupBy(r => r.Time.Value.Hours)
                    .Select(g => new { Hour = g.Key, Count = g.Count() })
                    .OrderByDescending(g => g.Count)
                    .Take(10)
                    .ToList();

                ViewBag.BusiestHours = busiestHours;

                // Günlük Randevu Doluluk Oranı (%)
                // ReservationDate tablosundan mevcut saatleri al
                var availableHoursToday = await db.ReservationsDate
                    .Where(rd => rd.BarberID == barberId &&
                                 rd.Date.Date == today &&
                                 rd.IsAvailable)
                    .CountAsync();

                int totalReservedHoursToday = todayReservations.Count;

                ViewBag.DailyOccupancyRate = availableHoursToday == 0
                    ? 0
                    : Math.Round((double)totalReservedHoursToday / availableHoursToday * 100, 1);

                // Ek debug bilgileri
                ViewBag.DebugAvailableHoursToday = availableHoursToday;
                ViewBag.DebugReservedHoursToday = totalReservedHoursToday;

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Hata: {ex.Message}";
                ViewBag.ErrorDetails = ex.InnerException?.Message;
                ViewBag.StackTrace = ex.StackTrace;

                // Boş değerler atayalım hata durumunda
                ViewBag.TotalReservations = 0;
                ViewBag.TotalThisMonth = 0;
                ViewBag.TotalThisWeek = 0;
                ViewBag.TotalToday = 0;
                ViewBag.HourlyIntensity = new List<object>();
                ViewBag.BusiestDays = new List<object>();
                ViewBag.BusiestHours = new List<object>();
                ViewBag.DailyOccupancyRate = 0;
                ViewBag.BarberName = "Bilinmiyor";

                return View();
            }
        }

        private DateTime StartOfWeek(DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
    }
}