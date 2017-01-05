using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NFL.Models.Player;
using NFL.Models.Player.Players_Information;

namespace NFL.Models.Players_Information
{
    public class Measurments
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression("^0?\\d{1}'(1[0-1]|0?[1-9])\"$", 
        ErrorMessage ="Height value should contains only numbers as examples  5'10\", 05'10\", 5'1\", or 5,01\"")]
        public string Tall { get; set; }

        [Required]
        [RegularExpression("^\\d{3}?$",
        ErrorMessage = "Weight value should be in Lbs and contain only numbers with exactly 3 digits")]
        public double weight { get; set; }


        [Required, Display(Name = "Arm Length")]
        [RegularExpression("^(0?[0-9]|[1-9][0-9])\"$",
        ErrorMessage = "Arm length value should be in inches and contain only numbers as examples  05\", 5\", or 25\"")]
        public string ArmLength { get; set; }

       // [RegularExpression("^(0|1|2)\\d{3}$",
       //ErrorMessage = "Year should contain only numbers of exactly 4 digits")]
        public int Year { get; set; }


        public string Position { get; set; }

        //One to One Relation

        [Required(ErrorMessage = "Please select a position")]
        public int mainPositionId { get; set; }
        public MainPosition mainPosition { get; set; }

        //One to Many relations

        public int informationId { get; set; }
        public virtual Information information { get; set; }
    }
}
