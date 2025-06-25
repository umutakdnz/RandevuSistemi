using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RandevuSistemi.Models.AdminSiniflar;

namespace RandevuSistemi.Controllers.BarberControllers
{
    [Authorize(AuthenticationSchemes = "BarberScheme")]
    public class ReservationHoursController : Controller
    {
        private readonly Context db;

        public ReservationHoursController(Context context)
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

        public IActionResult Index()
        {
            var currentBarberId = GetCurrentUserBarberId();

            if (currentBarberId == 0)
            {
                TempData["ErrorMessage"] = "Barber bilgisi alınamadı.";
                return RedirectToAction("Login", "Account");
            }

            var values = db.ReservationHours
                .Include(r => r.ReservationDays)
                .Where(r => r.ReservationDays.BarberId == currentBarberId)
                .OrderBy(r => r.ReservationDays.DayName)
                .ThenBy(r => r.TimeSlot)
                .ToList();

            return View(values);
        }

        public IActionResult DeleteReservationHours(int id)
        {
            var currentBarberId = GetCurrentUserBarberId();

            if (currentBarberId == 0)
            {
                TempData["ErrorMessage"] = "Berber bilgisi alınamadı.";
                return RedirectToAction("Index");
            }

            var values = db.ReservationHours
                .Include(r => r.ReservationDays)
                .FirstOrDefault(r => r.ReservationHoursID == id && r.ReservationDays.BarberId == currentBarberId);

            if (values != null)
            {
                db.ReservationHours.Remove(values);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Randevu saati başarıyla silindi.";
            }
            else
            {
                TempData["ErrorMessage"] = "Silinecek randevu saati bulunamadı.";
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateReservationHours(int id)
        {
            var currentBarberId = GetCurrentUserBarberId();

            if (currentBarberId == 0)
            {
                TempData["ErrorMessage"] = "Berber bilgisi alınamadı.";
                return RedirectToAction("Index");
            }

            var values = db.ReservationHours
                .Include(r => r.ReservationDays)
                .FirstOrDefault(r => r.ReservationHoursID == id && r.ReservationDays.BarberId == currentBarberId);

            if (values == null)
            {
                TempData["ErrorMessage"] = "Güncellenecek randevu saati bulunamadı.";
                return RedirectToAction("Index");
            }

            PopulateViewBags(currentBarberId, values.ReservationDaysID);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateReservationHours(ReservationHours model)
        {
            var currentBarberId = GetCurrentUserBarberId();

            if (currentBarberId == 0)
            {
                TempData["ErrorMessage"] = "Berber bilgisi alınamadı.";
                return RedirectToAction("Index");
            }

            try
            {
                // ModelState'i temizle ve sadece gerekli alanları kontrol et
                ModelState.Clear();

                if (model.ReservationDaysID <= 0)
                {
                    ModelState.AddModelError("ReservationDaysID", "Geçerli bir randevu günü seçiniz.");
                }

                if (model.TimeSlot == TimeSpan.Zero)
                {
                    ModelState.AddModelError("TimeSlot", "Geçerli bir saat giriniz.");
                }

                if (!ModelState.IsValid)
                {
                    PopulateViewBags(currentBarberId, model.ReservationDaysID);
                    return View(model);
                }

                var values = db.ReservationHours
                    .Include(r => r.ReservationDays)
                    .FirstOrDefault(r => r.ReservationHoursID == model.ReservationHoursID && r.ReservationDays.BarberId == currentBarberId);

                if (values != null)
                {
                    // Seçilen günün bu berbere ait olduğunu kontrol et
                    var reservationDay = db.ReservationsDays
                        .FirstOrDefault(d => d.ReservationDaysID == model.ReservationDaysID && d.BarberId == currentBarberId);

                    if (reservationDay == null)
                    {
                        ModelState.AddModelError("ReservationDaysID", "Seçilen gün bu berbere ait değil.");
                        PopulateViewBags(currentBarberId, model.ReservationDaysID);
                        return View(model);
                    }

                    // Aynı gün ve saatte başka randevu var mı kontrol et (mevcut kayıt hariç)
                    var existingHour = db.ReservationHours
                        .Any(h => h.ReservationDaysID == model.ReservationDaysID &&
                                 h.TimeSlot == model.TimeSlot &&
                                 h.ReservationHoursID != model.ReservationHoursID);

                    if (existingHour)
                    {
                        ModelState.AddModelError("TimeSlot", "Bu gün ve saatte zaten bir randevu saati mevcut.");
                        PopulateViewBags(currentBarberId, model.ReservationDaysID);
                        return View(model);
                    }

                    values.ReservationDaysID = model.ReservationDaysID;
                    values.TimeSlot = model.TimeSlot;
                    values.IsAvailable = model.IsAvailable;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = "Güncellenecek randevu saati bulunamadı.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                // Hata detayını logla
                System.Diagnostics.Debug.WriteLine($"Hata: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                ModelState.AddModelError("", "Bir hata oluştu. Lütfen tekrar deneyin.");
                PopulateViewBags(currentBarberId, model.ReservationDaysID);
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult CreateReservationHours()
        {
            var currentBarberId = GetCurrentUserBarberId();

            if (currentBarberId == 0)
            {
                TempData["ErrorMessage"] = "Berber kimliği alınamadı.";
                return RedirectToAction("Index");
            }

            ViewBag.BarberId = currentBarberId;
            PopulateViewBags(currentBarberId);

            return View(new ReservationHours
            {
                IsAvailable = true
            });
        }

        [HttpPost]
        public IActionResult CreateReservationHours(ReservationHours model)
        {
            var currentBarberId = GetCurrentUserBarberId();

            if (currentBarberId == 0)
            {
                TempData["ErrorMessage"] = "Berber kimliği alınamadı.";
                return RedirectToAction("Index");
            }

            // Navigation property'lerin validation hatalarını temizle
            ModelState.Remove("ReservationDays");
            ModelState.Remove("Reserveds");
            ModelState.Remove("ReservationDate");
            ModelState.Remove("Barber");


            // ModelState.Clear();  // Bu satır kaldırıldı

            if (model.ReservationDaysID <= 0)
            {
                ModelState.AddModelError("ReservationDaysID", "Randevu günü seçimi zorunludur.");
            }

            if (model.TimeSlot == TimeSpan.Zero)
            {
                ModelState.AddModelError("TimeSlot", "Saat bilgisi zorunludur.");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.BarberId = currentBarberId;
                PopulateViewBags(currentBarberId, model.ReservationDaysID);
                return View(model);
            }

            try
            {
                var reservationDay = db.ReservationsDays
                    .FirstOrDefault(d => d.ReservationDaysID == model.ReservationDaysID && d.BarberId == currentBarberId);

                if (reservationDay == null)
                {
                    ModelState.AddModelError("ReservationDaysID", "Seçilen gün bu berbere ait değil.");
                    ViewBag.BarberId = currentBarberId;
                    PopulateViewBags(currentBarberId, model.ReservationDaysID);
                    return View(model);
                }

                bool alreadyExists = db.ReservationHours.Any(r =>
                    r.ReservationDaysID == model.ReservationDaysID &&
                    r.TimeSlot == model.TimeSlot);

                if (alreadyExists)
                {
                    ModelState.AddModelError("TimeSlot", "Bu saat zaten mevcut.");
                    ViewBag.BarberId = currentBarberId;
                    PopulateViewBags(currentBarberId, model.ReservationDaysID);
                    return View(model);
                }

                var newReservationHour = new ReservationHours
                {
                    ReservationDaysID = model.ReservationDaysID,
                    TimeSlot = model.TimeSlot,
                    IsAvailable = model.IsAvailable,
                    BarberID = currentBarberId  // BURAYI EKLE
                };

                db.ReservationHours.Add(newReservationHour);
                db.SaveChanges();

                TempData["SuccessMessage"] = "Randevu saati başarıyla eklendi.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Hata: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                ModelState.AddModelError("", "Bir hata oluştu. Lütfen tekrar deneyin.");
                ViewBag.BarberId = currentBarberId;
                PopulateViewBags(currentBarberId, model.ReservationDaysID);
                return View(model);
            }
        }


        private void PopulateViewBags(int barberId, int? selectedReservationDaysID = null)
        {
            // ReservationDays ViewBag'ini düzelt
            var daysList = db.ReservationsDays
                .Where(d => d.BarberId == barberId)
                .Select(d => new SelectListItem
                {
                    Value = d.ReservationDaysID.ToString(),
                    Text = d.DayName,
                    Selected = (selectedReservationDaysID != null && d.ReservationDaysID == selectedReservationDaysID)
                })
                .ToList();

            // View'de aranan ViewBag adını kullan
            ViewBag.ReservationDays = daysList;
        }
    }
}