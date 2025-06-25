using Microsoft.AspNetCore.Mvc;
using RandevuSistemi.Models.AdminSiniflar;
using System.Linq; // LINQ sorguları için

namespace RandevuSistemi.Controllers.AdminControllers
{
    public class CategoriesController : Controller
    {
        private readonly Context db; // Bağımlılığı tanımla

        public CategoriesController(Context context) // Bağımlılığı constructor ile al
        {
            db = context;
        }
        public IActionResult Index()
        {
            var values = db.Categories.ToList(); // Veriyi çek
            return View(values);
        }

        public IActionResult DeleteCategory(int id)
        {
            var values = db.Categories.Find(id);
            db.Categories.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var values = db.Categories.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category model)
        {
            var values = db.Categories.Find(model.CategoryID);
            values.CategoryName = model.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        } 
    }
}
