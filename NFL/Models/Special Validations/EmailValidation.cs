using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NFL.Models.Player;
using NFL.Models;

namespace NFL.Models.Special_Validations
{
    public class EmailValidation : ValidationAttribute 
    {
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            
            if(validationContext.ObjectInstance.GetType() == typeof(ViewModelProfile))
            {
                var profile = (ViewModelProfile)validationContext.ObjectInstance;

                List<Email> emails = profile.Emails.ToList();

                emails.RemoveAll(em => em.email == null);

                if (emails.Count <= 0)
                    return new ValidationResult(ErrorMessages.AtLeastOneEmail);
            }

            else if(validationContext.ObjectInstance.GetType() == typeof(Email))
            {
                var email = (Email)validationContext.ObjectInstance;
                if (!String.IsNullOrEmpty(email.email) && String.IsNullOrEmpty(email.Type))
                    return new ValidationResult(ErrorMessages.SelectEmailType);
            }
           
            return ValidationResult.Success;
        }
    }
}
