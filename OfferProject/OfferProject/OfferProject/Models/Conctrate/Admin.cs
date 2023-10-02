using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OfferProject.Models.Conctrate
{
    public class Admin
    {
        public Admin() { }
        [Key]
        public int Admin_ID { get; set; }
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string userName { get; set; }
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string password { get; set; }

    }
}