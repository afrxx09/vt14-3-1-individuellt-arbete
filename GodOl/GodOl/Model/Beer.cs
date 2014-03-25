using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GodOl.Model
{
    public class Beer
    {
        public int BeerId { get; set; }

        public int BeerTypeId { get; set; }

        public int BreweryId { get; set; }

        [Required(ErrorMessage = "Namn krävs.")]
        [StringLength(30, ErrorMessage="Max 30 tecken i namnet.")]
        public string Name { get; set; }

        [RegularExpression(@"^[\d]{4}$", ErrorMessage="Årtal måste bestå av 4 siffror.")]
        public string StartYear { get; set; }
        
        [Range(0,100, ErrorMessage="Värde mellan 0 och 100.")]
        public double ABV { get; set; }

        [Range(0, 100, ErrorMessage = "Värde mellan 0 och 100.")]
        public int IBU { get; set; }

        [Range(0, 80, ErrorMessage = "Värde mellan 0 och 80.")]
        public int EBC { get; set; }
    }
}