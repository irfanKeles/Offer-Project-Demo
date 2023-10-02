using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OfferProject.Models.Conctrate
{
    public class Incoterm
    {
        public Incoterm()
        {
            status = true;
        }
        [Key]
        public int Incoterm_ID { get; set; }
        [StringLength(100)]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }
        public bool status { get; set; }
        //Offer
        public ICollection<Offer> offers { get; set; }
    }
}