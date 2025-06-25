using Microsoft.AspNetCore.Mvc;
using RandevuSistemi.Models.AdminSiniflar;

namespace RandevuSistemi.Controllers.AdminControllers
{
    public class PriceController : Controller
    {
        private readonly Context db;

        public PriceController(Context context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var values = db.Prices.ToList();
            return View(values);
        }

        public IActionResult DeletePrice(int id)
        {
            var values = db.Prices.Find(id);
            db. Prices.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreatePrice()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePrice(Price price)
        {
            db.Prices.Add(price);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdatePrice(int id)
        {
            var values = db.Prices.Find(id);
            return View(values);
        }

        [HttpPost]

        public IActionResult UpdatePrice(Price model)
        {
            var values = db.Prices.Find(model.PriceID);
            values.PriceName = model.PriceName;
            values.Description = model.Description;
            values.PriceLink = model.PriceLink;
            values.Image1 = model.Image1;
            values.CategoryID = model.CategoryID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
