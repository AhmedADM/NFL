using NFL.Models.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NFL.Models.Stadiums
{
    public class Stadium
    {
        public int Id { get; set; }
        public List<string> Names { get; set; }

        public Address Address { get; set; }

        public DateTime DateEstablished { get; set; }

        public int Capacity { get; set; }

        public List<string> CEOs { get; set; }
    }
}