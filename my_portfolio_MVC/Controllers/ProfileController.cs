using my_portfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace my_portfolio_MVC.Controllers
{
    public class ProfileController : Controller
    {
        myporfolioEntities db = new myporfolioEntities();
        public ActionResult Index()
        {
            string email = Session["email"].ToString();
            if(string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Index","login ");
            }
            var admin = db.Tbl_Admins.FirstOrDefault(x => x.Email == email);
            return View(admin);
        }
        [HttpPost]
        public ActionResult Index(Tbl_Admins model)
        {
            string email = Session["email"].ToString();

            var admin = db.Tbl_Admins.FirstOrDefault(x => x.Email == email);

            if (admin.Password == model.Password)
            {
               if (model.ImageFile != null)
                { 
                    var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var savelocation = currentDirectory + "images\\";
                    var fileName = Path.Combine(savelocation, model.ImageFile.FileName);
                    model.ImageFile.SaveAs(fileName);
                    admin.ImageUrl = "/images/" + model.ImageFile.FileName;
                }
                admin.Name = model.Name;
                admin.Surname = model.Surname;
                admin.Email = model.Email;
                db.SaveChanges();
                Session.Abandon();
                return RedirectToAction("Index", "login");

            }
            ModelState.AddModelError("", "Şifre hatalı");
            return View(model);
        }
    }
}