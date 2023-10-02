using FluentValidation.Results;
using OfferProject.Models.Conctrate;
using OfferProject.ValidationRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OfferProject.Controllers
{
    public class AdminLoginController : Controller
    {
        MyDbContext myDbContext = new MyDbContext();
        // GET: AdminLogin
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            AdminValidator validationRules = new AdminValidator();
            ValidationResult result = validationRules.Validate(admin);
            if (result.IsValid)
            {
                var sessionsInfo = myDbContext.admins.FirstOrDefault(x => x.userName == admin.userName && x.password == admin.password);
                if (sessionsInfo != null)
                {
                    FormsAuthentication.SetAuthCookie(sessionsInfo.userName, true);
                    Session["userName"] = sessionsInfo.userName.ToString();
                    return RedirectToAction("Dashboard", "Admin");
                }
                else
                {
                    ViewBag.erorMessage = "Username or Password is incorrect.";
                    return View();
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult AdminLogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login");
        }

    }
}