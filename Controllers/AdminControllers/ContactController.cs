using Microsoft.AspNetCore.Mvc;
using RandevuSistemi.Models.AdminSiniflar;

namespace RandevuSistemi.Controllers.AdminControllers
{
    public class ContactController : Controller
    {
        private readonly Context db;

        public ContactController(Context context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var values = db.Contacts.ToList();
            return View(values);
        }

        public IActionResult DeleteContact(int id)
        {
            var values = db.Contacts.Find(id);
            db.Contacts.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateContact(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateContact(int id)
        {
            var values =db.Contacts.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateContact(Contact model)
        {
            var values = db.Contacts.Find(model.ContactID);
            values.Description = model.Description;
            values.Adress = model.Adress;
            values.Email = model.Email;
            values.Phone = model.Phone;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
