using Microsoft.AspNetCore.Mvc;
using RandevuSistemi.Models.AdminSiniflar;

namespace RandevuSistemi.Controllers.AdminControllers
{
    public class CommentsController : Controller
    {
        private readonly Context db;

        public CommentsController(Context context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var values = db.Comments.ToList();
            return View(values);
        }

        public IActionResult DeleteComments(int id)
        {
            var values = db.Comments.Find(id);
            db.Comments.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateComments()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateComments(Comments comments)
        {
            db.Comments.Add(comments);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateComments(int id)
        {
            var values = db.Comments.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateComments(Comments model)
        {
            var values = db.Comments.Find(model.CommentsID);
            values.Description1 = model.Description1;
            values.COmmentsName = model.COmmentsName;
            values.Description2 = model.Description2;
            values.ImageUrl = model.ImageUrl;
            values.Title = model.Title;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
