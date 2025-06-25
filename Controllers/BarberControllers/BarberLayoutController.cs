using Microsoft.AspNetCore.Mvc;

namespace RandevuSistemi.Controllers.BarberControllers
{
    public class BarberLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PartialHead()
        {
            return PartialView();
        }

        public IActionResult PartialNavbar()
        {
            return PartialView();
        }

        public IActionResult PartialSidebar()
        {
            return PartialView();
        }

        public IActionResult PartialScript()
        {
            return PartialView();
        }
    }
}
