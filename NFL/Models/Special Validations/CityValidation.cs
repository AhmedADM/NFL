//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;

//using NFL.Models.Player;
//using NFL.Models;

//namespace NFL.Models.Special_Validations
//{
//    public class CityValidation : ValidationAttribute
//    {
//        private ApplicationDbContext _context;


//        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//        {

//            _context = validationContext.GetService<ApplicationDbContext>();
//            var address = (Address)validationContext.ObjectInstance;
//            var InputCity = address.City;
//            var cityInDB = _context.Cities.SingleOrDefault(c => c.ZipCode == InputCity.ZipCode
//                                                && c.City.Equals(InputCity.City)
//                                                && c.State.Equals(InputCity.State));

//            return (cityInDB == null) ?
//                new ValidationResult(ErrorMessages.InvalidLocation) : ValidationResult.Success;
//        }

//    }
//}
