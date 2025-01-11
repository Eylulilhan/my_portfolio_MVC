using my_portfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace my_portfolio_MVC.Controllers
{
    public class BannerController : Controller
    {
        myporfolioEntities db = new myporfolioEntities();
        public ActionResult Index()
        {
            var values = db.Tbl_Banners.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult UpdateBanner(int id)
        {
            var values = db.Tbl_Banners.Find(id);

            ViewBag.TrueFalseList = new List<SelectListItem>
            {
            new SelectListItem { Text = "Evet", Value = "true", Selected = values.isShown == true },
            new SelectListItem { Text = "Hayır", Value = "false", Selected = values.isShown == false }
            };


            return View(values);

        }
        [HttpPost]
        public ActionResult UpdateBanner(Tbl_Banners Model)
        {
            var values = db.Tbl_Banners.Find(Model.bannerid);
            values.isShown = Model.isShown;
            values.title = Model.title;
            values.dicsreption = Model.dicsreption;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult AddBanner()
        {
            ViewBag.TrueFalseList = new List<SelectListItem>
        {
        new SelectListItem { Text = "Evet", Value = "true" },
        new SelectListItem { Text = "Hayır", Value = "false" }
        };



            return View();
        }
        [HttpPost]
        public ActionResult AddBanner(Tbl_Banners Model)
        {
            db.Tbl_Banners.Add(Model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBanner(int id)
        {
            var value = db.Tbl_Banners.Find(id);
            db.Tbl_Banners.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}