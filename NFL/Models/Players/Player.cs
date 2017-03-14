using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NFL.Models.Addresses;
using System.ComponentModel.DataAnnotations.Schema;
using NFL.Models.Profile;

namespace NFL.Models.Player
{
    public class Player
    {

        [Key]
        public int playerId { get; set; }

        [NotMapped]
        public PersonalInformation personalInformation { get; set; }

        [NotMapped]
        public  ContactInformation contactInformation { get; set; }


        //Inner join to partyAddress Table
        public string AddressIds { get; set; }

        [NotMapped]
        public List<Address> Addresses { get; set; }

        public virtual Information OtherInformation { get; set; }

    }
}
