using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OfferProject.Models.Conctrate
{
    public class Users
    {
        public Users()
        {
            status = true;
            birtday = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        }
        [Key]
        public int User_ID { get; set; }
        [StringLength(100)]
        [Column(TypeName = "varchar")]
        public string name { get; set; }
        [StringLength(100)]
        [Column(TypeName = "varchar")]
        public string surname { get; set; }
        [StringLength(20)]
        [Column(TypeName = "varchar")]
        public string password { get; set; }
        [StringLength(70)]
        [Column(TypeName = "varchar")]
        public string mail { get; set; }
        public DateTime birtday { get; set; }
        public bool gender { get; set; }
        public bool status { get; set; }
        //Offer
        public ICollection<Offer> offers { get; set; }
    }
}