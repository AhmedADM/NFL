using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NFL.Models.Player;

namespace NFL.Models.Players_Information
{
    public class Education_History
    {

        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        //[Required, RegularExpression("[a-zA-Z]", ErrorMessage = "The University/School Name should contain words a-z or A-Z or both")]
        public string Name { get; set; }

        [Required]
        //[Required, RegularExpression("[a-zA-Z]", ErrorMessage = "The degree Name should contain words a-z or A-Z or both")]
        public string Degree { get; set; }

        [Required, RegularExpression("^[a-zA-Z]+[,. /-] ?[a-zA-Z]+$", ErrorMessage = "Invalid location")]
        public string Location { get; set; }

        [Display(Name = "Graduation Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM  yyyy}")]
        public DateTime Date { get; set; }



        //One to Many relations

        public int informationId { get; set; }
        public virtual Information information { get; set; }
    }
}
