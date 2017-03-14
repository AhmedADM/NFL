using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NFL.Models.Experiences
{
    public class Experience
    {
        public int Id { get; set; }


        [Required,
        RegularExpression("^[a-zA-Z -]+$",
        ErrorMessage = "Your organization name should contain letters a-z or A-Z or both"),
        MinLength(2)]
        public string Organization { get; set; }


        [Required,
        RegularExpression("^[a-zA-Z -]+$",
        ErrorMessage = "Role field should contain letters a-z or A-Z or both"),
        MinLength(2)]
        public string Role { get; set; }


        public DateTime DateFrom { get; set; }


        public DateTime? DateTo { get; set; }

        public string Description { get; set; }






        public int personId { get; set; }

        public string Person { get; set; }

    }
}