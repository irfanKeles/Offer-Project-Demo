using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OfferProject.Models.Conctrate
{
    public class Offer
    {
        //public IEnumerable<SelectListItem> countriesEn { get; set; }
        //public IEnumerable<SelectListItem> cityesEn { get; set; }
        //public IEnumerable<SelectListItem> modeEn { get; set; }
        //public IEnumerable<SelectListItem> unit1En { get; set; }
        //public IEnumerable<SelectListItem> unit2En { get; set; }
        //public IEnumerable<SelectListItem> packageTypeEn { get; set; }
        //public IEnumerable<SelectListItem> currencyEn { get; set; }
        //public IEnumerable<SelectListItem> movementTypeEn { get; set; }
        //public IEnumerable<SelectListItem> ıncotermEn { get; set; }
        public Offer()
        {
            status = false;
            delete = false;
            offerDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        }
        [Key]
        public int Offer_ID { get; set; }


        //City
        public int? City_ID { get; set; }
        public virtual City City { get; set; }
        //Countries
        public int? Countries_ID { get; set; }
        public virtual Countries Countries { get; set; }
        //Currency
        public int? Currency_ID { get; set; }
        public virtual Currency Currency { get; set; }
        //Incoterm
        public int? Incoterm_ID { get; set; }
        public virtual Incoterm Incoterm { get; set; }
        //Mode
        public int? Mode_ID { get; set; }
        public virtual Mode Mode { get; set; }
        //MovementType
        public int? MovementType_ID { get; set; }
        public virtual MovementType MovementType { get; set; }
        //PackageType
        public int? PackageType_ID { get; set; }
        public virtual PackageType PackageType { get; set; }
        //Unit-1
        public int? Unit1_ID { get; set; }
        public virtual Unit1 Unit1 { get; set; }
        //Unit-2
        public int? Unit2_ID { get; set; }
        public virtual Unit2 Unit2 { get; set; }
        //Users
        public int? User_ID { get; set; }
        public virtual Users Users { get; set; }

        public DateTime offerDate { get; set; }
        public bool status { get; set; }
        public bool delete { get; set; }
    }
}