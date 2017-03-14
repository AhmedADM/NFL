using NFL.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NFL.Models.Staff
{
    public class OffensiveCoaches
    {
        public int Id { get; set; }


        public Employee OffensiveCoordinator { get; set; }

        public Employee RunGameCoordinator { get; set; }


        public Employee QuarterbackCoach { get; set; }


        //And more staff to add later
    }
}