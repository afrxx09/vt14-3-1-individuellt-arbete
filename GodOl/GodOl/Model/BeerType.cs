using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GodOl.Model
{
    public class BeerType
    {
        public int BeerTypeId { get; set; }

        //Fail... can't name the property "BeerType"(Field name in Database)
        [Required(ErrorMessage="BeerType krävs.")]
        [StringLength(25, ErrorMessage="Max 25 tecken.")]
        public string BType { get; set; }
    }
}