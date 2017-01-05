using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using NFL.Models.Player;
using NFL.Models.Players_Information;

namespace NFL.Models
{
    [Serializable]
    public class Location
    {

        [Key]

        public int Id { get; set; }

        [Required, RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "City should contain only letters a-z or A-Z or both")]
        public string City { get; set; }
        public string County { get; set; }

        [Required]
        public string State { get; set; }


        public String StateName { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        [RegularExpression("^\\d{5}?$", ErrorMessage = "The zip Code accepts only numbers of exactly 5 digits")]
        public int ZipCode { get; set; }


        public float lat { get; set; }
        public float lng { get; set; }



        //Assign one to many

        public virtual List<Address> Addresses { get; set; }
    }
}
