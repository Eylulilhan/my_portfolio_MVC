using my_portfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace my_portfolio_MVC.Controllers
{
    public class ContactController : Controller
    {
        myporfolioEntities db = new myporfolioEntities();
        public ActionResult Index()
        {
            var values = db.Tbl_Contacts.ToList();
            return View(values);
        }
        public ActionResult DeleteContact(int id)
        {
            var value = db.Tbl_Contacts.Find(id);
            db.Tbl_Contacts.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var value = db.Tbl_Contacts.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateContact(Tbl_Contacts model)
        {
            var value = db.Tbl_Contacts.Find(model.Contactid);
            value.Pnone = model.Pnone;  
            value.Email = model.Email;  
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContact(Tbl_Contacts model)
        {
            db.Tbl_Contacts.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}