using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RandevuSistemi.Models.AdminSiniflar;

namespace RandevuSistemi.Controllers.BarberControllers
{
    [Authorize(AuthenticationSchemes = "BarberScheme")]
    public class ProfileController : BaseController
    {
        private readonly Context db;
        public ProfileController(Context context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            int barberId = GetCurrentUserBarberId();

            if (barberId == 0)
            {
                return RedirectToAction("Index", "BarberLogin");
            }

            // BarberID'ye göre filtreleme yapıyoruz
            var values = db.Hairdressers
                .Where(h => h.BarberID == barberId)
                .ToList();

            return View(values);
        }

        [HttpGet]
        public IActionResult UpdateProfile(int id)
        {
            int barberId = GetCurrentUserBarberId();
            if (barberId == 0)
                return RedirectToAction("Index", "BarberLogin");

            var profile = db.Hairdressers
                .FirstOrDefault(h => h.BarberID == barberId);

            if (profile == null)
                return NotFound();

            return View(profile);
        }

        [HttpPost]
        public IActionResult UpdateProfile(Hairdresser model)
        {
            int barberId = GetCurrentUserBarberId();
            if (barberId == 0)
                return RedirectToAction("Index", "BarberLogin");

            var profile = db.Hairdressers
                .FirstOrDefault(h => h.BarberID == barberId);

            if (profile == null)
                return NotFound();

            profile.Name = model.Name;
            profile.Email = model.Email;
            profile.Phone = model.Phone;
            profile.Role = model.Role;
            profile.Password = model.Password;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
