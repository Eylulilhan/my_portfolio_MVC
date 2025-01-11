using my_portfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace my_portfolio_MVC.Controllers
{
    public class TestimonialController : Controller
    {
        myporfolioEntities db = new myporfolioEntities();
        public ActionResult Index()
        {
            var values = db.Tbl_Testimonials.ToList();
            return View(values);
        }
        public ActionResult DeleteTestimonial(int id)
        {
            var value = db.Tbl_Testimonials.Find(id);
            db.Tbl_Testimonials.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = db.Tbl_Testimonials.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(Tbl_Testimonials model, HttpPostedFileBase file)
        {
            var value = db.Tbl_Testimonials.Find(model.Testimonialid);

            {
                if (model.ImageFile != null)
                {
                    var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var saveLocation = currentDirectory + "images\\";
                    var fileName = Path.Combine(saveLocation, model.ImageFile.FileName);
                    model.ImageFile.SaveAs(fileName);
                    model.imageUrl = "/images/" + model.ImageFile.FileName;
                }

            }
            value.Title = model.Title;
            value.NameSurname = model.NameSurname;
            value.imageUrl = model.imageUrl;
            value.Comment = model.Comment;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTestimonial(Tbl_Testimonials model, HttpPostedFileBase file)

        {
            if (model.ImageFile != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "images\\";
                var fileName = Path.Combine(saveLocation, model.ImageFile.FileName);
                model.ImageFile.SaveAs(fileName);
                model.imageUrl = "/images/" + model.ImageFile.FileName;
            }
            db.Tbl_Testimonials.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}