using Microsoft.AspNetCore.Mvc;
using RandevuSistemi.Models.AdminSiniflar;

namespace RandevuSistemi.Controllers.AdminControllers
{
    public class SocialMediaController : Controller
    {
        private readonly Context db;

        public SocialMediaController(Context context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var values = db.SocialMedias.ToList();
            return View(values);
        }

        public IActionResult DeleteSocialMedia(int id)
        {
            var values = db.SocialMedias.Find(id);
            db.SocialMedias.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(SocialMedia socialMedia)
        {
            db.SocialMedias.Add(socialMedia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            var values = db.SocialMedias.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateSocialMedia(SocialMedia model)
        {
            var values = db.SocialMedias.Find(model.SocialMediaID);
            values.SocialName = model.SocialName;
            values.SocialLink = model.SocialLink;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
