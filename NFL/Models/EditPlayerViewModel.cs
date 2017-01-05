using NFL.Models.Player;
using NFL.Models.Player.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NFL
{
    public class EditPlayerViewModel
    {
        public Player player { get; set; }
        public ViewModelProfile ViewModelProfile { get; set; }
        public ViewModelPlayerInfo ViewModelPlayerInfo { get; set; }
    }
}