using my_portfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace my_portfolio_MVC.Controllers
{
    public class ProjectController : Controller
    {
        myporfolioEntities db = new myporfolioEntities();
        private void CategoryDropDown()
        {
            var categoryList = db.Tbl_Categories.ToList();
           
            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.Categoryid.ToString()
                                               }
                                              ).ToList();
            ViewBag.Categories = categories;
        }
        public ActionResult Index()
        {
            var projects = db.Tbl_Procets.ToList();
            return View(projects);
        }
        [HttpGet]
        public ActionResult CreateProject()
        {
            CategoryDropDown();
            return View();
        }
        [HttpPost]  
        public ActionResult CreateProject(Tbl_Procets model)
        {
            
            return View();
            if (!ModelState.IsValid)
            { 
                return View(model); 
            }

            db.Tbl_Procets.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }

        public ActionResult DeleteProject(int id)
        {
            var value = db.Tbl_Procets.Find(id);
            db.Tbl_Procets.Remove(value);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            CategoryDropDown();
            var value = db.Tbl_Procets.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateProject(Tbl_Procets model)
        {
            CategoryDropDown();
            var value = db.Tbl_Procets.Find(model.Projectid);
            value.Name =model.Name;
            value.imageUrl =model.imageUrl;
            value.Description =model.Description;
            value.Categoryid = model.Categoryid;
            value.GitHubUrl = model.GitHubUrl;
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            db.SaveChanges();
            return RedirectToAction("index");

        }
    }
}