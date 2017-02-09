using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;


namespace NFL.Models.Addresses
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

    }
}
