using my_portfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace my_portfolio_MVC.Controllers
{
    public class AdminLayoutController : Controller
    {
       
        myporfolioEntities db = new myporfolioEntities();   
        public ActionResult Layout()
        {
            return View();
        }
        public PartialViewResult AdminLayoutHead()
        {
            return PartialView();
        }
        public PartialViewResult AdminLayoutSpinner()
        {
            return PartialView();   
        }
        public PartialViewResult AdminLayoutSidebar()
        {
            var email = Session["email"].ToString();
            var admin = db.Tbl_Admins.FirstOrDefault(x => x.Email == email);
            ViewBag.namesurname = admin.Name + " " + admin.Surname;
            ViewBag.imageurl = admin.ImageUrl;
            return PartialView();
            
        }
        public PartialViewResult AdminLayoutNavbar()
        {
            var email = Session["email"].ToString();   
            var admin = db.Tbl_Admins.FirstOrDefault(x => x.Email == email);    
            ViewBag.namesurname= admin.Name + " " + admin.Surname;   
            ViewBag.imageurl = admin.ImageUrl;
            return PartialView();
        }
        public PartialViewResult AdminLayoutFooter()
        {
            return PartialView();
        }
        public PartialViewResult AdminLayoutScripts()
        {
            return PartialView();
        }   
    }
}