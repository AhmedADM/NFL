using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using NFL.Models.Players_Information;
namespace NFL.Models.Player
{
    [Serializable()]
    public class PersonalInformation
    {

        private DateTime _BirthDate;

        [XmlIgnore]
        [Key, ForeignKey("Player")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int playerId { get; set; }
        public virtual Player Player { get; set; }

        [Required, 
        RegularExpression("^[a-zA-Z]+$",
        ErrorMessage = "Your first name should contain letters a-z or A-Z or both"),
        MinLength(2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Display(Name ="Last Name")]
        [Required,
        RegularExpression("^[a-zA-Z]+$",
        ErrorMessage = "Your last name should contain letters a-z or A-Z or both"),
        MinLength(2)]
        public string LastName { get; set; }


        [Required]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM  yyyy}")]
        public DateTime BirthDate {
            get { return _BirthDate; }
            set { _BirthDate = value; }
        }

        [XmlIgnore]
        public byte Age
        {

            get
            {
                DateTime now = DateTime.Today;
                byte age = Convert.ToByte(now.Year - _BirthDate.Year);
                if (now < _BirthDate.AddYears(age)) age--;
                return age;
            }

        }

        [Required (ErrorMessage = "Please select gender")]
        public string Gender { get; set; }

        
    }
}
