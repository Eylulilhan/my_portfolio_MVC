using my_portfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace my_portfolio_MVC.Controllers
{
    public class AboutController : Controller
    {
        myporfolioEntities db = new myporfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblAbouts.ToList();
            return View(values);
        }
        public ActionResult DeleteAbout(int id)
        {
            var values = db.TblAbouts.Find(id);
            db.TblAbouts.Remove(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddAbout(int id)
        {
            var vaules = db.TblAbouts.Find(id);
            return View(vaules);
        }
        [HttpPost]
        public ActionResult AddAbout(TblAbout model, HttpPostedFileBase dosya)
        {
            var values = db.TblAbouts.Find(model.Aboutid);
            if (model.ImageFile != null && model.CV != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "images\\";
                var fileName = Path.Combine(saveLocation, model.ImageFile.FileName);
                model.ImageFile.SaveAs(fileName);
                model.imageUrl = "/images/" + model.ImageFile.FileName;
                var saveLocation2 = currentDirectory + "CV\\";
                var fileName2 = Path.Combine(saveLocation2, model.CV.FileName);
                model.CV.SaveAs(fileName2);
                model.CvUrl = "/CV/" + model.CV.FileName;
            }
            values.imageUrl = model.imageUrl;
            values.Title = model.Title;
            values.Description = model.Description;
            values.CvUrl = model.CvUrl;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}