using my_portfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace my_portfolio_MVC.Controllers
{
    public class ExpertiseController : Controller
    {
        myporfolioEntities db = new myporfolioEntities();   
        public ActionResult Index()
        {
            var values = db.Tbl_Expertises.ToList();
            return View(values);
        }
        public ActionResult DeleteExpertise(int id)
        {
            var value = db.Tbl_Expertises.Find(id);
            db.Tbl_Expertises.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateExpertise(int id)
        {
            var value = db.Tbl_Expertises.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateExpertise(Tbl_Expertises model)
        {
            var value = db.Tbl_Expertises.Find(model.Expertiseid);
            value.Title = model.Title;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CreateExpertise()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateExpertise(Tbl_Expertises model)
        {
            if (model == null || string.IsNullOrEmpty(model.Title))
            {
                return View();
            }
            db.Tbl_Expertises.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }   
    }
}