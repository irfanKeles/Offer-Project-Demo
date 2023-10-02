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
    public class userLoginController : Controller
    {
        // GET: userLogin
        MyDbContext myDbContext = new MyDbContext();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Users users)
        {
            UserLoginValidator validationRules = new UserLoginValidator();
            ValidationResult result = validationRules.Validate(users);
            if (result.IsValid)
            {
                var sessionsInfo = myDbContext.users.FirstOrDefault(x => x.mail == users.mail && x.password == users.password && x.status == true);
                if (sessionsInfo != null)
                {
                    FormsAuthentication.SetAuthCookie(sessionsInfo.mail, true);
                    Session["mail"] = sessionsInfo.mail.ToString();
                    return RedirectToAction("Index", "userHome");
                }
                else
                {
                    ViewBag.erorMessage = "Email Address or Password is incorrect.";
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
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Users users)
        {
            UserRegisterValidator validationRules = new UserRegisterValidator();
            ValidationResult result = validationRules.Validate(users);
            if (result.IsValid)
            {
                users.gender = true;
                myDbContext.users.Add(users);
                myDbContext.SaveChanges();
                return RedirectToAction("Login");
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
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}