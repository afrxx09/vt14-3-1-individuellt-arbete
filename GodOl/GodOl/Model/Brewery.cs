using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GodOl.Model
{
    public class Brewery
    {
        public int BreweryId { get; set; }

        [Required(ErrorMessage="Namn krävs.")]
        [StringLength(30, ErrorMessage = "Namn får max innehålla 30 tecken.")]
        public string Name { get; set; }

        [Required(ErrorMessage="Address kräövs.")]
        [StringLength(30, ErrorMessage="Address får max innehålla 30 tecken.")]
        public string Adress { get; set; }

        [StringLength(30, ErrorMessage = "Address2 får max innehålla 30 tecken.")]
        public string Adress2 { get; set; }

        [Required(ErrorMessage = "Stad krävs.")]
        [StringLength(30, ErrorMessage = "Stad får max innehålla 30 tecken.")]
        public string City { get; set; }

        [StringLength(30, ErrorMessage = "Stat / province får max innehålla 30 tecken.")]
        public string State { get; set; }

        [Required(ErrorMessage = "Postnummer krävs.")]
        [StringLength(10, ErrorMessage = "Postnummer får max innehålla 10 tecken.")]
        public string Zip { get; set; }

        [RegularExpression(@"^[\d]{4}$", ErrorMessage = "Årtal måste bestå av 4 siffror.")]
        public string Established { get; set; }

        [Required(ErrorMessage="Land krävs")]
        [StringLength(2, ErrorMessage="Land får endast bestå av två bokstäver")]
        public string Nationality { get; set; }
    }
}