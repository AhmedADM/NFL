using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using NFL.Models.Player;
using NFL.Models.Special_Validations;

namespace NFL.Models
{
    [Serializable]
    public class Email
    {
        public int Id { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string email { get; set; }


        //[EmailValidation]
        [Required(ErrorMessage = "Please select Type")]
        public string Type { get; set; }


        //public int contactInformationId { get; set; }

        public virtual ContactInformation contactInformation { get; set; }
    }
}
