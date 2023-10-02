using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OfferProject.Models.Conctrate
{
    public class MovementType
    {
        public MovementType()
        {
            status = true;
        }
        [Key]
        public int MovementType_ID { get; set; }
        [StringLength(70)]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }
        public bool status { get; set; }
        //Offer
        public ICollection<Offer> offers { get; set; }
    }
}