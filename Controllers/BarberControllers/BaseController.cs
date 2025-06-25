using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace RandevuSistemi.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// Oturum açmış kullanıcının BarberID'sini getirir.
        /// Veritabanında "BarberID" şeklinde tanımlıdır.
        /// </summary>
        /// <returns>BarberID (int) ya da 0</returns>
        protected int GetCurrentUserBarberId()
        {
            var barberIdClaim = User.Claims.FirstOrDefault(c => c.Type == "BarberID");
            if (barberIdClaim != null && int.TryParse(barberIdClaim.Value, out int barberId))
            {
                return barberId;
            }

            // Eğer BarberID yoksa, diğer claim tiplerini dene
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                return userId;
            }

            // Son çare olarak "Id" claim'ini dene
            var idClaim = User.Claims.FirstOrDefault(c => c.Type == "Id");
            if (idClaim != null && int.TryParse(idClaim.Value, out int id))
            {
                return id;
            }
            return 0; // Giriş yapılmamışsa veya BarberID eklenmemişse
        }
    }
}

