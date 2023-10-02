using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OfferProject.Models.Conctrate
{
    public class City
    {
        public City()
        {
            status = true;
        }
        [Key]
        public int City_ID { get; set; }
        [StringLength(100)]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }
        public bool status { get; set; }

        //Countries
        public int Countries_ID { get; set; }
        public virtual Countries Countries { get; set; }
        //Offer
        public ICollection<Offer> offers { get; set; }
    }
}