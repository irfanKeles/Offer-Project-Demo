using FluentValidation.Results;
using Newtonsoft.Json;
using OfferProject.Models.Conctrate;
using OfferProject.Models.IEnumerable;
using OfferProject.ValidationRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OfferProject.Controllers
{
    [Authorize]
    public class userHomeController : Controller
    {
        MyDbContext myDbContext = new MyDbContext();
        Offer ofs = new Offer();
        // GET: userHome
        public userHomeController()
        {
            List<SelectListItem> Mode = (from item in myDbContext.modes.ToList()
                                         select new SelectListItem
                                         {
                                             Text = item.Name,
                                             Value = item.Mode_ID.ToString()
                                         }).ToList();
            List<SelectListItem> MovementType = (from item in myDbContext.movementTypes.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = item.Name,
                                                     Value = item.MovementType_ID.ToString()
                                                 }).ToList();
            List<SelectListItem> Incoterm = (from item in myDbContext.ıncoterms.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = item.Name,
                                                 Value = item.Incoterm_ID.ToString()
                                             }).ToList();
            List<SelectListItem> PackageType = (from item in myDbContext.packageTypes.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = item.Name,
                                                    Value = item.PackageType_ID.ToString()
                                                }).ToList();
            List<SelectListItem> Unit1 = (from item in myDbContext.unit1s.ToList()
                                          select new SelectListItem
                                          {
                                              Text = item.Name,
                                              Value = item.Unit1_ID.ToString()
                                          }).ToList();
            List<SelectListItem> Unit2 = (from item in myDbContext.unit2s.ToList()
                                          select new SelectListItem
                                          {
                                              Text = item.Name,
                                              Value = item.Unit2_ID.ToString()
                                          }).ToList();
            List<SelectListItem> Currency = (from item in myDbContext.currencies.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = item.Name,
                                                 Value = item.Currency_ID.ToString()
                                             }).ToList();
            List<SelectListItem> Countries = (from item in myDbContext.countries.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = item.Name,
                                                  Value = item.Countries_ID.ToString()
                                              }).ToList();
            List<SelectListItem> City = (from item in myDbContext.cities.ToList()
                                         select new SelectListItem
                                         {
                                             Text = item.Name,
                                             Value = item.City_ID.ToString()
                                         }).ToList();
            ViewBag.mode = Mode;
            ViewBag.movementType = MovementType;
            ViewBag.incoterm = Incoterm;
            ViewBag.packageType = PackageType;
            ViewBag.unit1 = Unit1;
            ViewBag.unit2 = Unit2;
            ViewBag.currency = Currency;
            ViewBag.contries = Countries;
            ViewBag.city = City;
        }
        public int userId()
        {
            var userMail = (string)Session["mail"];
            var getMail = myDbContext.users.FirstOrDefault(x => x.mail == userMail);
            var user_id = getMail.User_ID;
            ViewBag.userID = user_id;
            ViewBag.nameSurname = getMail.name + " " + getMail.surname;
            ViewBag.genderString = (getMail.gender == true) ? "Man" : "Women";
            ViewBag.gender = getMail.gender;
            return user_id;
        }
        public ActionResult Index()
        {
            int id = userId();
            return View(myDbContext.users.Where(x => x.User_ID == id).ToList());
        }
        [HttpGet]
        public ActionResult GiveOfferPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GiveOfferPage(Offer offer)
        {
            OfferValidator validationRules = new OfferValidator();
            ValidationResult result = validationRules.Validate(offer);
            if (result.IsValid)
            {
                offer.User_ID = userId();
                myDbContext.offers.Add(offer);
                myDbContext.SaveChanges();
                return RedirectToAction("OfferMade");
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
        public ActionResult Profile()
        {
            return View();
        }
        public ActionResult OfferMade()
        {
            int id = userId();
            var list = myDbContext.offers.Where(x => x.User_ID == id).Where(y => y.delete == false).OrderByDescending(z=>z.Offer_ID).ToList();
            return View(list);
        }
        public ActionResult OfferDelete(int id)
        {
            var delete = myDbContext.offers.Find(id);
            delete.delete = true;
            myDbContext.SaveChanges();
            return RedirectToAction("OfferMade");
        }
        [HttpGet]
        public ActionResult OfferEdit(int id)
        {
            var data = myDbContext.offers.Find(id);
            ViewBag.edit = id;
            return View("OfferEdit", data);
        }
        [HttpPost]
        public ActionResult OfferEdit(Offer offer)
        {
            OfferValidator validationRules = new OfferValidator();
            ValidationResult result = validationRules.Validate(offer);
            if (result.IsValid)
            {
                var update = myDbContext.offers.Find(offer.Offer_ID);
                update.City_ID = offer.City_ID;
                update.Countries_ID = offer.Countries_ID;
                update.Currency_ID = offer.Currency_ID;
                update.Incoterm_ID = offer.Incoterm_ID;
                update.Mode_ID = offer.Mode_ID;
                update.MovementType_ID = offer.MovementType_ID;
                update.PackageType_ID = offer.PackageType_ID;
                update.Unit1_ID = offer.Unit1_ID;
                update.Unit2_ID = offer.Unit2_ID;
                myDbContext.SaveChanges();
                return RedirectToAction("OfferMade");
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
        public ActionResult ProfileSettings()
        {
            int id = userId();
            var user = myDbContext.users.Find(id);
            return View("ProfileSettings", user);
        }
        [HttpPost]
        public ActionResult ProfileSettings(Users u)
        {
            UserRegisterValidator validationRules = new UserRegisterValidator();
            ValidationResult result = validationRules.Validate(u);
            if (result.IsValid)
            {
                int id = userId();
                ViewBag.userID = id;
                var userUpdate = myDbContext.users.Find(u.User_ID);
                userUpdate.name = u.name;
                userUpdate.surname = u.surname;
                userUpdate.gender = u.gender;
                userUpdate.birtday = u.birtday;
                userUpdate.password = u.password;
                userUpdate.mail = u.mail;
                userUpdate.gender = u.gender;
                myDbContext.SaveChanges();
                return RedirectToAction("ProfileSettings");
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
        public ActionResult OfferDetail(int id)
        {
            ViewBag.id = id;
            var list = myDbContext.offers.Where(x => x.Offer_ID == id).ToList();
            return PartialView(list);
        }
        public JsonResult city(int p)
        {
            var citys = (from x in myDbContext.cities
                         join y in myDbContext.countries on x.Countries.Countries_ID equals y.Countries_ID
                         where x.Countries.Countries_ID == p
                         select new
                         {
                             Text = x.Name,
                             Value = x.City_ID.ToString()
                         }).ToList();
            return Json(citys, JsonRequestBehavior.AllowGet);
        }
    }
}