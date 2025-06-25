using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RandevuSistemi.Models.AdminSiniflar;
using System.Globalization;

namespace RandevuSistemi.Controllers.UserControllers
{
    public class ReservedController : Controller
    {
        private readonly Context db;
        public ReservedController(Context context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var barbers = db.Barbers.ToList();
            ViewBag.BarberList = new SelectList(barbers, "BarberId", "BarberName");
            return View();
        }
        [HttpPost]
        public IActionResult Index(Reserved reserved, string selectedDate)
        {
            // Seçilen tarihi randevu nesnesine ata
            if (!string.IsNullOrEmpty(selectedDate) && DateTime.TryParse(selectedDate, out DateTime reservationDate))
            {
                reserved.ReservationDate = reservationDate;
            }
            else
            {
                reserved.ReservationDate = DateTime.Now; // Fallback
            }

            // Randevuyu kaydet
            db.Reserveds.Add(reserved);
            db.SaveChanges();

            // ReservationDate tablosunda seçilen tarih ve saatin müsaitlik durumunu güncelle
            var selectedReservationDate = db.ReservationsDate
                .FirstOrDefault(rd => rd.Date.Date == reserved.ReservationDate.Date &&
                                      rd.ReservationHourId == reserved.ReservationHoursID);

            if (selectedReservationDate != null)
            {
                selectedReservationDate.IsAvailable = false; // Artık müsait değil
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // AJAX ile seçilen berbere göre günleri getir
        [HttpGet]
        public JsonResult GetDaysByBarber(int barberId)
        {
            var days = db.ReservationsDays
                .Where(d => d.BarberId == barberId)
                .Select(d => new { d.ReservationDaysID, d.DayName })
                .ToList();
            return Json(days);
        }

        // AJAX ile seçilen güne göre saatleri getir (ReservationDate tablosundan)
        [HttpGet]
        public JsonResult GetHoursByDay(int dayId, string selectedDate = null)
        {
            DateTime? filterDate = null;
            if (!string.IsNullOrEmpty(selectedDate) && DateTime.TryParse(selectedDate, out DateTime parsedDate))
            {
                filterDate = parsedDate.Date;
            }

            var query = from rd in db.ReservationsDate
                        join rh in db.ReservationHours on rd.ReservationHourId equals rh.ReservationHoursID
                        where rh.ReservationDaysID == dayId
                        select new { rd, rh };

            // Eğer tarih belirtilmişse, o tarihe ait saatleri filtrele
            if (filterDate.HasValue)
            {
                query = query.Where(x => x.rd.Date.Date == filterDate.Value && x.rd.IsAvailable == true);
            }
            else
            {
                // Tarih belirtilmemişse, genel olarak müsait saatleri getir
                query = query.Where(x => x.rd.IsAvailable == true);
            }

            var hours = query
                .Select(x => new {
                    ReservationHoursID = x.rh.ReservationHoursID,
                    TimeSlot = x.rh.TimeSlot,
                    ReservationDateID = x.rd.ReservationDateID,
                    Date = x.rd.Date
                })
                .ToList();

            return Json(hours);
        }

        [HttpGet]
        public JsonResult GetReservationDates(int barberId)
        {
            // Kullanıcının tanımlı günlerini alıyoruz
            var availableDays = db.ReservationsDays
                .Where(rd => rd.BarberId == barberId)
                .Select(rd => new { rd.ReservationDaysID, rd.DayName })
                .ToList();

            // Türkçe gün ve ay isimleri için kültür ayarı
            CultureInfo culture = new CultureInfo("tr-TR");
            DateTime today = DateTime.Today;
            List<object> dateOptions = new List<object>();
            int daysToSearch = 30; // Önümüzdeki 30 gün içinde uygun günleri ara

            for (int i = 0; i < daysToSearch; i++)
            {
                var currentDate = today.AddDays(i);
                string dayName = culture.DateTimeFormat.GetDayName(currentDate.DayOfWeek);

                var matchingDay = availableDays.FirstOrDefault(d => d.DayName == dayName);
                if (matchingDay != null)
                {
                    // Bu tarih için ReservationDate tablosunda müsait slot var mı kontrol et
                    bool hasAvailableSlots = db.ReservationsDate
                        .Any(rd => rd.Date.Date == currentDate.Date &&
                                  rd.IsAvailable == true &&
                                  db.ReservationHours.Any(rh => rh.ReservationHoursID == rd.ReservationHourId &&
                                                                rh.ReservationDaysID == matchingDay.ReservationDaysID));

                    if (hasAvailableSlots)
                    {
                        string formattedDate = $"{currentDate:dd MMMM yyyy} {dayName}";
                        dateOptions.Add(new
                        {
                            ReservationDaysID = matchingDay.ReservationDaysID,
                            DisplayText = formattedDate,
                            Date = currentDate.ToString("yyyy-MM-dd")
                        });
                    }
                }
            }
            return Json(dateOptions);
        }

        // Opsiyonel: Randevu iptal edildiğinde müsaitlik durumunu geri açmak için
        [HttpPost]
        public IActionResult CancelReservation(int reservedId)
        {
            var reservation = db.Reserveds.FirstOrDefault(r => r.ReservedID == reservedId);
            if (reservation != null)
            {
                // ReservationDate tablosunda ilgili kaydı tekrar müsait yap
                var reservationDate = db.ReservationsDate
                    .FirstOrDefault(rd => rd.Date.Date == reservation.ReservationDate.Date &&
                                          rd.ReservationHourId == reservation.ReservationHoursID);

                if (reservationDate != null)
                {
                    reservationDate.IsAvailable = true;
                    db.SaveChanges();
                }

                // Randevuyu sil
                db.Reserveds.Remove(reservation);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
