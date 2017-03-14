using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NFL.Models.Staff
{
    public class Staff
    {
        public int Id { get; set; }

        public FrontOffice frontOffice { get; set; }

        public OffensiveCoaches offensiveCoaches { get; set; }


        //And  More staff to add later
    }
}