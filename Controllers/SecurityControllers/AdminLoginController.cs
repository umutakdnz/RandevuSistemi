using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandevuSistemi.Models.AdminSiniflar;
using System;
using System.Security.Claims;

namespace RandevuSistemi.Controllers.SecurityControllers
{
    public class AdminLoginController : Controller
    {
        private readonly Context _context;

        public AdminLoginController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(); // Login sayfası
        }
       
        [HttpPost]
        public async Task<IActionResult> Index(string username, string password)
        {
            // Veritabanında kullanıcı adı ve şifre eşleşmesi kontrolü
            var admin = await _context.AdminLogin.FirstOrDefaultAsync(a => a.username == username && a.password == password);

            if (admin != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, admin.username)
                };

                //var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //var principal = new ClaimsPrincipal(identity);

                //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                var identity = new ClaimsIdentity(claims, "AdminScheme");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("AdminScheme", principal);


                return RedirectToAction("Index", "Categories"); // Giriş sonrası yönlendirme
            }

            ViewBag.Error = "Kullanıcı adı veya şifre hatalı.";
            return View(); // Hatalı girişte tekrar login ekranı
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}

