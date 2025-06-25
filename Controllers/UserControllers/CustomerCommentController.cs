using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RandevuSistemi.Models.AdminSiniflar;

namespace RandevuSistemi.Controllers.UserControllers
{
    public class CustomerCommentController : Controller
    {
        private readonly Context db;
        public CustomerCommentController(Context _context)
        {
            db = _context;
        }
        public IActionResult Index()
        {
            var values = db.CustomerComments.Include(r => r.Barber).ToList();
            return View(values);
        }

        public IActionResult DeleteCustomerComment(int id)
        {
            var customerComment = db.CustomerComments.Find(id);
            if (customerComment == null)
            {
                return NotFound();
            }

            var comment = db.Comments.FirstOrDefault(x => x.Description2 == customerComment.Description && x.COmmentsName == customerComment.CustomerName && x.Title == customerComment.Title);
            db.CustomerComments.Remove(customerComment);

            if (comment != null)
            {
                db.Comments.Remove(comment);
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateCustomerComment()
        {
            var barbers = db.Barbers.ToList();
            ViewBag.BarberList = new SelectList(barbers, "BarberId", "BarberName");
            return View();
        }

        [HttpPost]
        public IActionResult CreateCustomerComment(CustomerComment customerComment)
        {
            db.CustomerComments.Add(customerComment);
            db.SaveChanges();

            Comments comment = new Comments
            {
                Description2 = customerComment.Description,
                COmmentsName = customerComment.CustomerName,
                Title = customerComment.Title
            };

            db.Comments.Add(comment);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCustomerComment(int id)
        {
            var values = db.CustomerComments.Find(id);
            var barbers = db.Barbers.ToList();
            ViewBag.BarberList = new SelectList(barbers, "BarberName", "BarberName", values.BarberId);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateCustomerComment(CustomerComment model)
        {
            // 1. CustomerComments kaydını bul
            var customer = db.CustomerComments.Find(model.CustomerCommentID);

            if (customer == null)
            {
                return NotFound();
            }

            // 2. Güncellemeden önce eski değerleri sakla
            string oldName = customer.CustomerName;
            string oldTitle = customer.Title;
            string oldDescription = customer.Description;

            // 3. CustomerComments tablosunu güncelle
            customer.Description = model.Description;
            customer.CustomerName = model.CustomerName;
            customer.Title = model.Title;

            // 4. Comments tablosundaki eski değerlerle eşleşen kaydı bul
            var comment = db.Comments.FirstOrDefault(x => x.COmmentsName == oldName && x.Title == oldTitle && x.Description2 == oldDescription);

            // 5. Eğer eşleşen Comments kaydı varsa onu da güncelle
            if (comment != null)
            {
                comment.Description2 = model.Description;
                comment.COmmentsName = model.CustomerName;
                comment.Title = model.Title;
            }

            // 6. Değişiklikleri kaydet
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
