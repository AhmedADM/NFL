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
    public class Fax
    {
        [XmlIgnore]
        public int Id { get; set; }

        [RegularExpression("\\+[0-9]{1,3}\\([0-9]{3}\\)[0-9]{7}", ErrorMessage = "Invalid fax number")]
        public string Number { get; set; }


        [FaxValidation]
        public string Type { get; set; }


        //public int contactInformationId { get; set; }

        public virtual ContactInformation contactInformation { get; set; }
    }
}
