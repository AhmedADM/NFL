using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NFL.Models.Addresses
{
    public class partyAddress
    {
        public int Id { get; set; }
        public int partyId { get; set; }
        public int addressId { get; set; }

        public string party { get; set; }

        [Display(Name = "Date from")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM  yyyy}")]
        public DateTime? from { get; set; }


        [Display(Name = "Date to")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM  yyyy}")]
        public DateTime? to { get; set; }
    }
}