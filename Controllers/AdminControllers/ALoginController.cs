using Microsoft.AspNetCore.Mvc;
using RandevuSistemi.Models.AdminSiniflar;

namespace RandevuSistemi.Controllers.AdminControllers
{
    public class ALoginController : Controller
    {
        private readonly Context db;
        public ALoginController(Context context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var values = db.AdminLogin.ToList();
            return View(values);
        }

        public IActionResult DeleteALogin(int id)
        {
            var values = db.AdminLogin.Find(id);
            db.AdminLogin.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateALogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateALogin(AdminLogin adminLogin)
        {
            db.AdminLogin.Add(adminLogin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateALogin(int id)
        {
            var values = db.AdminLogin.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateALogin(AdminLogin model)
        {
            var values = db.AdminLogin.Find(model.ID);
            values.username = model.username;
            values.password = model.password;   
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
