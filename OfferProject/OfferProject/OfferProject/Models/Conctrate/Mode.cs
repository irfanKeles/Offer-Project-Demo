using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OfferProject.Models.Conctrate
{
    public class Mode
    {
        public Mode()
        {
            status = true;
        }
        [Key]
        public int Mode_ID { get; set; }
        [StringLength(10)]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }
        public bool status { get; set; }
        //Offer
        public ICollection<Offer> offers { get; set; }
    }
}