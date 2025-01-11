using my_portfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace my_portfolio_MVC.Controllers
{
    public class SocialMediaController : Controller
    {
        myporfolioEntities db = new myporfolioEntities();
        public ActionResult Index()
        {
            var values = db.Tbl_Socials.ToList();
            return View(values);
        }
        public ActionResult DeleteSocialMedia(int id)
        {
            var value = db.Tbl_Socials.Find(id);
            db.Tbl_Socials.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var value = db.Tbl_Socials.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateSocialMedia(Tbl_Socials model)
        {
            var value = db.Tbl_Socials.Find(model.SocialMediaid);
            value.name = model.name;
            value.url = model.url;  
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]   
        public ActionResult CreateSocialMedia()
        {
            return View();  
        }
        [HttpPost]
        public ActionResult CreateSocialMedia(Tbl_Socials model)
        {
            if (model == null || string.IsNullOrEmpty(model.name) || string.IsNullOrEmpty(model.url))
            {
                return View();

            }
            
                db.Tbl_Socials.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            
        }
    }
}