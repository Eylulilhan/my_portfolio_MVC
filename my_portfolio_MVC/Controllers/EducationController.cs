using my_portfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace my_portfolio_MVC.Controllers
{
    public class EducationController : Controller
    {
        myporfolioEntities db = new myporfolioEntities();
        public ActionResult Index()
        {
            var educations = db.Tbl_Educations.ToList();
            return View(educations);
        }
        public ActionResult DeleteEducation(int id)
        {
            var value = db.Tbl_Educations.Find(id);
            db.Tbl_Educations.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");   
            
        }
        [HttpGet]
        public ActionResult CreateEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateEducation(Tbl_Educations model)
        {
            db.Tbl_Educations.Add(model);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
           public ActionResult UpdateEducation(int id)
        {
            var education = db.Tbl_Educations.Find(id);
            return View(education);
        }
        [HttpPost]  
        public ActionResult UpdateEducation(Tbl_Educations model)
        {
            var value = db.Tbl_Educations.Find(model.Educationid);
            value.SchoolName= model.SchoolName;
            value.Description= model.Description;   
            value.StartDate= model.StartDate;   
            value.EndTime= model.EndTime;   
            value.Degree= model.Degree; 
            value.Department= model.Department;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}