using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using NFL.Models.Player;
using NFL.Models.Special_Validations;

namespace NFL.Models
{
    [Serializable]
    public class Phone
    {
        [XmlIgnore]
        public int Id { get; set; }

 
        //[RegularExpression("^(001|\+1)?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$")] For complete phone number
        [RegularExpression("^(\\([2-9]\\d{2}\\)|[2-9]\\d{2})[- .]?\\d{3}[- .]?\\d{4}$", ErrorMessage = "Invalid phone number")]
        public string Number { get; set; }

        [PhoneValidation]
        public string Type { get; set; }


        //public int contactInformationId { get; set; }

        public virtual ContactInformation contactInformation { get; set; }
    }
}
