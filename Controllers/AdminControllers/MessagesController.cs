using Microsoft.AspNetCore.Mvc;
using RandevuSistemi.Models.AdminSiniflar;

namespace RandevuSistemi.Controllers.AdminControllers
{
    public class MessagesController : Controller
    {
        private readonly Context db;

        public MessagesController(Context context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var values = db.Messages.ToList();
            return View(values);
        }

        public IActionResult DeleteMessages(int id)
        {
            var values = db.Messages.Find(id);
            db.Messages.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateMessages()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMessages(Messages messages)
        {
            db.Messages.Add(messages);
            db.SaveChanges();
            return RedirectToAction("Index");
        } 

        [HttpGet]
        public IActionResult UpdateMessages(int id)
        {
            var values = db.Messages.Find(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateMessages(Messages model)
        {
            var values = db.Messages.Find(model.MessagesID);
            values.NameSurname = model.NameSurname;
            values.Mail = model.Mail;
            values.Subject = model.Subject;
            values.MessageContent = model.MessageContent;
            db.SaveChanges();
            return RedirectToAction("Index");
        } 
    }
}
