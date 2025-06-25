using Microsoft.AspNetCore.Mvc;
using RandevuSistemi.Models.AdminSiniflar;

namespace RandevuSistemi.Controllers.AdminControllers
{
    public class CampaignsController : Controller
    {
        private readonly Context db;

        public CampaignsController(Context context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var values = db.Campaigns.ToList();
            return View(values);
        }

        public IActionResult DeleteCampaigns(int id)
        {
            var values = db.Campaigns.Find(id);
            db.Campaigns.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateCampaigns()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCampaigns(Campaigns campaigns)
        {
            db.Campaigns.Add(campaigns);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCampaigns(int id)
        {
            var values = db.Campaigns.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateCampaigns(Campaigns model)
        {
            var values = db.Campaigns.Find(model.CampaignsId);
            values.Title = model.Title;
            values.Description = model.Description;
            values.StartDate = model.StartDate;
            values.EndDate = model.EndDate;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
