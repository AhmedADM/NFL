using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NFL.Models.Player;
using NFL.Models;

namespace NFL.Models.Special_Validations
{
    public class PhoneValidation :ValidationAttribute
    {
      
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (validationContext.ObjectInstance.GetType() == typeof(ViewModelProfile))
            {
                var profile = (ViewModelProfile)validationContext.ObjectInstance;

                List<Phone> phones = profile.Phones.ToList();

                phones.RemoveAll(em => em.Number == null);

                if (phones.Count <= 0)
                    return new ValidationResult(ErrorMessages.AtLeastOnePhone);
            }

            else if (validationContext.ObjectInstance.GetType() == typeof(Phone))
            {
                var phone = (Phone)validationContext.ObjectInstance;
                if (!String.IsNullOrEmpty(phone.Number) && String.IsNullOrEmpty(phone.Type))
                    return new ValidationResult(ErrorMessages.SelectPhoneType);
            }

            return ValidationResult.Success;
        }
    }
}
