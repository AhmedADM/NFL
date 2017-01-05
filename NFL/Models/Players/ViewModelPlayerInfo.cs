using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NFL.Models.Player.Players_Information;
using NFL.Models.Players_Information;

namespace NFL.Models.Player.Profile
{
    public class ViewModelPlayerInfo
    {
        public int Id { get; set; }
        //Player Information
        

        [Required, MinLength(100)]
        public string Bio { get; set; }
        public Education_History Education { get; set; }
        public Measurments Measurment { get; set; }

        public List<MainPosition> MainPositions { get; set; }

        public static implicit operator ViewModelPlayerInfo(ViewModelProfile v)
        {
            throw new NotImplementedException();
        }
    }
}
