using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using NFL.Models.Player;
using NFL.Models.Players_Information;

namespace NFL.Models.Profile
{
    public class ContactInformation
    {

        public int Id { get; set; }


        public int personId { get; set; }
        public string Person { get; set; }

        public virtual List<Email> Emails { get; set; }
        public virtual List<Phone> PhoneNumbers { get; set; }
        public virtual List<Fax> Faxes { get; set; }


    }
}
