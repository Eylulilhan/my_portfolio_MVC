using my_portfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace my_portfolio_MVC.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        myporfolioEntities db =new myporfolioEntities();
        public ActionResult Index()
        {
            var values = db.Tbl_Messages.Where(m =>m.IsRead==false).ToList();
            return View(values);
        }
        public ActionResult MessageDetail(int id)
        {
            var value = db.Tbl_Messages.Find(id);
            value.IsRead = true;
            db.SaveChanges();
            return View(value);  
        }
        [HttpPost]
        public ActionResult MakeMessageRead(int id)
        {
            var value = db.Tbl_Messages.Find(id);
            value.IsRead = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public PartialViewResult FindMessage()
        {
            var values = db.Tbl_Messages.Where(m => m.IsRead == false).OrderByDescending(m => m.Messageid).Take(3).ToList(); 
            return PartialView(values);

        }   
    }
}