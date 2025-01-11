using my_portfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace my_portfolio_MVC.Controllers
{
   
    public class CategoryController : Controller
    {
        myporfolioEntities db = new myporfolioEntities();   

        public ActionResult Index()
        {
            var values = db.Tbl_Categories.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateCategory()
        { 
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(Tbl_Categories category)
        {
            db.Tbl_Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index"); 
        }

        public ActionResult DeleteCategory(int id)
        {
            var Value = db.Tbl_Categories.Find(id);
            db.Tbl_Categories.Remove(Value);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = db.Tbl_Categories.Find(id);
            return View(value); 
        }
        [HttpPost]
        public ActionResult UpdateCategory(Tbl_Categories model)
        {
            var value = db.Tbl_Categories.Find(model.Categoryid);
            value.Name = model.Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}