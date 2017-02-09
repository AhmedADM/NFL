using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using NFL.Models.Player;
using NFL.Models.Special_Validations;
using ExpressiveAnnotations.Attributes;

namespace NFL.Models
{
    [Serializable]
    public class Email
    {
        public int Id { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string email { get; set; }


        //[EmailValidation]
        [RequiredIf("email != null", ErrorMessage = ErrorMessages.SelectEmailType)]
        public string Type { get; set; }


        //public int contactInformationId { get; set; }

        public virtual ContactInformation contactInformation { get; set; }

       
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!String.IsNullOrEmpty(Type) && String.IsNullOrEmpty(Type))
                yield return new ValidationResult(ErrorMessages.SelectEmailType);
        }
    }
}
