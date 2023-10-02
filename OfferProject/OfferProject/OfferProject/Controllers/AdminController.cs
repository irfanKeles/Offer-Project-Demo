using FluentValidation.Results;
using OfferProject.Models.Conctrate;
using OfferProject.ValidationRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OfferProject.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        MyDbContext myDbContext = new MyDbContext();
        // GET: Admin
        public AdminController()
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
            List<SelectListItem> User = (from item in myDbContext.users.ToList()
                                         select new SelectListItem
                                         {
                                             Text = item.name + " " + item.surname,
                                             Value = item.User_ID.ToString()
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
            ViewBag.user = User;
        }
        public int AdminId()
        {
            var adminUserName = (string)Session["userName"];
            var getUserName = myDbContext.admins.FirstOrDefault(x => x.userName == adminUserName);
            var admin_id = getUserName.Admin_ID;
            return admin_id;
        }
        public ActionResult Dashboard()
        {
            ViewBag.total = myDbContext.offers.Count().ToString();
            ViewBag.success = myDbContext.offers.Where(x => x.status == true).Count();
            ViewBag.pending = myDbContext.offers.Where(x => x.status == false).Where(y => y.delete == false).Count();
            ViewBag.delete = myDbContext.offers.Where(x => x.delete == true).Count();
            return View();
        }
        public ActionResult userList()
        {
            return PartialView(myDbContext.users.ToList());
        }
        public ActionResult ModeList()
        {
            return PartialView(myDbContext.modes.ToList());
        }
        public ActionResult PackageTypeList()
        {
            return PartialView(myDbContext.packageTypes.ToList());
        }
        public ActionResult MovementTypeList()
        {
            return PartialView(myDbContext.movementTypes.ToList());
        }
        public ActionResult CountriyList()
        {
            return PartialView(myDbContext.countries.ToList());
        }
        public ActionResult CityList()
        {
            return PartialView(myDbContext.cities.ToList());
        }
        public ActionResult IncotermList()
        {
            return PartialView(myDbContext.ıncoterms.ToList());
        }
        public ActionResult CurrencyList()
        {
            return PartialView(myDbContext.currencies.ToList());
        }
        public ActionResult Unit1List()
        {
            return PartialView(myDbContext.unit1s.ToList());
        }
        public ActionResult Unit2List()
        {
            return PartialView(myDbContext.unit2s.ToList());
        }
        public ActionResult AdminOfferList()
        {
            return View(myDbContext.offers.OrderByDescending(x => x.status == false).ToList());
        }
        public ActionResult AdminOfferDeleteList()
        {
            return PartialView(myDbContext.offers.Where(x => x.delete == true).ToList());
        }
        public ActionResult AdminDeleteOffer(int id)
        {
            var delete = myDbContext.offers.Find(id);
            delete.delete = true;
            delete.status = false;
            myDbContext.SaveChanges();
            return RedirectToAction("AdminOfferList");
        }
        public ActionResult AdmiSuccessOffer(int id)
        {
            var delete = myDbContext.offers.Find(id);
            delete.status = true;
            myDbContext.SaveChanges();
            return RedirectToAction("AdminOfferList");
        }
        [HttpGet]
        public ActionResult AdminUpdateOffer(int id)
        {
            var data = myDbContext.offers.Where(x => x.Offer_ID == id && x.status == false).FirstOrDefault();
            if (data != null)
            {
                return View(data);
            }
            else
            {
                ViewBag.errorMessage = "Bu kullanıcı için işlem yapamazsınız !";
                return View();
            }
        }

        [HttpPost]
        public ActionResult AdminUpdateOffer(Offer offer)
        {
            OfferAdminValidator validationRules = new OfferAdminValidator();
            ValidationResult result = validationRules.Validate(offer);
            if (result.IsValid)
            {
                var data = myDbContext.offers.Find(offer.Offer_ID);
                data.User_ID = offer.User_ID;
                data.Countries_ID = offer.Countries_ID;
                data.City_ID = offer.Countries_ID;
                data.Mode_ID = offer.Countries_ID;
                data.Currency_ID = offer.Currency_ID;
                data.Incoterm_ID = offer.Incoterm_ID;
                data.MovementType_ID = offer.MovementType_ID;
                data.PackageType_ID = offer.PackageType_ID;
                data.Unit1_ID = offer.Unit1_ID;
                data.Unit2_ID = offer.Unit2_ID;
                data.status = offer.status;
                myDbContext.SaveChanges();
                return RedirectToAction("AdminOfferList");
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
        public JsonResult CityListAdmin(int p)
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