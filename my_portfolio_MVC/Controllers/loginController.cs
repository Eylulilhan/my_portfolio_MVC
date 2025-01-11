using my_portfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace my_portfolio_MVC.Controllers
{
    [AllowAnonymous]    // Bu kısım yetkilendirme kısmından muaf tutulmuştur.
    public class loginController : Controller
    {
        myporfolioEntities db = new myporfolioEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Tbl_Admins model)
        {
            var value = db.Tbl_Admins.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            if (value == null)
            {
                ModelState.AddModelError("", "Email veya şifre hatalı");
                return View(model);
            }
            FormsAuthentication.SetAuthCookie(value.Email, false);

            Session["email"] = value.Email;
            return RedirectToAction("Index", "Category");

        }
    }
}