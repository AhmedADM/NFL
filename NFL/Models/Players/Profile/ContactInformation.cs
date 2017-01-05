using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using NFL.Models.Player;
using NFL.Models.Players_Information;

namespace NFL.Models.Player
{
    public class ContactInformation
    {
      
        [Key, ForeignKey("Player")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int playerId { get; set; }
        public  Player Player { get; set; }


        public virtual List<Email> Emails { get; set; }
        public virtual List<Phone> PhoneNumbers { get; set; }
        public virtual List<Fax> Faxes { get; set; }


    }
}
