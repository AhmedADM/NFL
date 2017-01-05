using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NFL.Models.Players_Information;

namespace NFL.Models.Player.Players_Information
{
    public class MainPosition
    {
        public int Id { get; set; }

        [Display(Name = "Position")]
        public string Abbriviation { get; set; }


        public string Position { get; set; }

    }
}
