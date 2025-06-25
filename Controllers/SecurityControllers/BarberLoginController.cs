using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandevuSistemi.Models.AdminSiniflar;
using System.Security.Claims;

namespace RandevuSistemi.Controllers.SecurityControllers
{
    public class BarberLoginController : Controller
    {
        private readonly Context _context;

        public BarberLoginController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(); // Giriş sayfası
        }

        [HttpPost]
        public async Task<IActionResult> Index(string role, string password)
        {
            // Role ve şifreyi veritabanında kontrol et
            var barber = await _context.Hairdressers
                .FirstOrDefaultAsync(h => h.Role == role && h.Password == password);

            if (barber != null)
            {
                if (barber.BarberID == null || barber.BarberID == 0)
                {
                    ViewBag.Error = "Bu kullanıcıya bağlı bir BerberID bulunamadı. Lütfen yöneticinize başvurun.";
                    return View();
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, barber.Role),
                    new Claim("HairdresserID", barber.HairdresserID.ToString()),
                    new Claim("BarberID", barber.BarberID.ToString()) //ID ye göre 
                };

                //var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //var principal = new ClaimsPrincipal(identity);

                //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                var identity = new ClaimsIdentity(claims, "BarberScheme");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("BarberScheme", principal);


                return RedirectToAction("Index", "Appointments"); // Giriş başarılıysa yönlendir
            }

            ViewBag.Error = "Rol veya şifre hatalı.";
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

        // === ŞİFREMİ UNUTTUM ===

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var barber = await _context.Hairdressers
                .FirstOrDefaultAsync(h => h.Email == email);

            if (barber != null)
            {
                TempData["Email"] = email;
                TempData["Role"] = barber.Role;
                return RedirectToAction("ResetPassword");
            }

            ViewBag.Error = "E-posta bulunamadı.";
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword()
        {
            ViewBag.Email = TempData["Email"];
            TempData.Keep("Email"); // <- BU SATIR ZORUNLU!
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(string email, string role, string newPassword, string confirmPassword)
        {
            if (string.IsNullOrEmpty(email))
            {
                ViewBag.Error = "E-posta bilgisi alınamadı. Lütfen işlemi yeniden başlatın.";
                return View();
            }

            if (newPassword != confirmPassword)
            {
                ViewBag.Email = email; // Yeniden view'a gönder
                ViewBag.Error = "Yeni şifreler eşleşmiyor.";
                return View();
            }

            var barber = await _context.Hairdressers
                .FirstOrDefaultAsync(h => h.Email == email && h.Role == role);

            if (barber != null)
            {
                barber.Password = newPassword;
                await _context.SaveChangesAsync();

                TempData["Success"] = "Şifreniz başarıyla güncellendi.";
                return RedirectToAction("Index");
            }

            ViewBag.Email = email; // Tekrar view'a gönder
            ViewBag.Error = "Bu e-posta adresi ile kullanıcı adı (Role) eşleşmiyor.";
            return View();
        }
    }
}
