using my_portfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace my_portfolio_MVC.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        myporfolioEntities db = new myporfolioEntities();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult DefaultBanner()
        {
            var values = db.Tbl_Banners.Where(x => x.isShown == true).ToList();//Buradaki x değeri veri tabanındaki banner tablosunda ki bütün değerlere denk geliyor.
            return PartialView(values);
        }
        public PartialViewResult DefaultExpertise()
        {
            var values = db.Tbl_Expertises.ToList();
            return PartialView(values);

        }
        public PartialViewResult DefaultExperience()
        {
            var values = db.Tbl_Experiences.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultEducation()
        {
            var values = db.Tbl_Educations.ToList();
            return PartialView(values);

        }
        public PartialViewResult DefaultProjet()
        {
            var values = db.Tbl_Procets.ToList();
            return PartialView(values);
        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {

            return PartialView();
        }

        [HttpPost]
        public ActionResult SendMessage(Tbl_Messages model)
        {
            model.IsRead = false;
            db.Tbl_Messages.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult DefaultAbout()
        {
            var values = db.TblAbouts.ToList(); 
            return PartialView(values);
        }

        public PartialViewResult DefaultSocial()
        {
            var values = db.Tbl_Socials.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultTestimonial()
        {
            var values = db.Tbl_Testimonials.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultContact()
        {
            var values = db.Tbl_Contacts.ToList();  
            return PartialView(values);
        }   

    }
}