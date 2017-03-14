using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NFL.Models;
using NFL.Models.Profile;

namespace NFL.Models.Special_Validations
{
    public class FaxValidation : ValidationAttribute
    {


        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var fax = (Fax)validationContext.ObjectInstance;
            if (!String.IsNullOrEmpty(fax.Number) && String.IsNullOrEmpty(fax.Type))
                return new ValidationResult(ErrorMessages.SelectFaxType);


            return ValidationResult.Success;
        }
    }
}
