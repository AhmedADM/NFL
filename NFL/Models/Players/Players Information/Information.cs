using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using NFL.Models.Players_Information;

namespace NFL.Models.Player
{
    public class Information
    {
        [Key, ForeignKey("Player")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int informationId { get; set; }
        public Player Player { get; set; }


        [MinLength(100)]
        public string Bio { get; set; }

        public virtual List<Education_History> Educations { get; set; }

        public virtual List<Measurments> Measurments { get; set; }

    }
}
