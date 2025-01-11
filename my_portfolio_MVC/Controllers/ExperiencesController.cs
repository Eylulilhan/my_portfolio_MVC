using my_portfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace my_portfolio_MVC.Controllers
{
    public class ExperiencesController : Controller
    {
        myporfolioEntities db = new myporfolioEntities();   
        public ActionResult Index()
        {
            var values = db.Tbl_Experiences.ToList();   
            return View(values);
        }
        public ActionResult DeleteExperiences(int id)
        {
            var value = db.Tbl_Experiences.Find(id);
            db.Tbl_Experiences.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }
        [HttpGet]
        public ActionResult UpdateExperiences(int id)
        {
            var value = db.Tbl_Experiences.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateExperiences(Tbl_Experiences model)
        {
            var value = db.Tbl_Experiences.Find(model.Experienceid);
            value.CompanyName = model.CompanyName;
            value.Title = model.Title;
            value.StartDate = model.StartDate;
            value.EndDate = model.EndDate;
            value.Description = model.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddExperiences()
        {
            return View();
        }   
        [HttpPost]
        public ActionResult AddExperiences(Tbl_Experiences model)
        {
            db.Tbl_Experiences.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }   
    }
}