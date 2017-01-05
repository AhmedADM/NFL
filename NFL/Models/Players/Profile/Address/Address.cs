using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using NFL.Models.Players_Information;
using NFL.Models.Special_Validations;

namespace NFL.Models.Player
{
    [Serializable]
    public class Address
    {
  
        [XmlIgnore]
        public int Id { get; set; }

        [Required]
   
        public string Street { get; set; }


        //Many to One relation Each city can have more than ONE street Address

        public int locationId { get; set; }

        //[CityValidation]
        public virtual Location Location { get; set; }


        public int playerId { get; set; }



        public virtual Player Player { get; set; }

    }
}
