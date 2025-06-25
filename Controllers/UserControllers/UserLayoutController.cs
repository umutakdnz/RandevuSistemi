using Microsoft.AspNetCore.Mvc;

namespace RandevuSistemi.Controllers.UserControllers
{
    public class UserLayoutController : Controller
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
