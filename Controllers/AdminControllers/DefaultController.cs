using Microsoft.AspNetCore.Mvc;

namespace RandevuSistemi.Controllers.AdminControllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
