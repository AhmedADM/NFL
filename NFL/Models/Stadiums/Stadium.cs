
using NFL.Models.Addresses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFL.Models
{
    public class Stadium
    {
        public int Id { get; set; }

        [Required,
        RegularExpression("^[a-zA-Z- ]+$",
        ErrorMessage = ErrorMessages.NotCorrectStadiumName)]

        [Display(Name = "Name")]
        public string Names { get; set; }

        //Inner join to partyAddress Table
        public int AddressId { get; set; }

        [NotMapped]
        public  Address Address { get; set; }


        [Display(Name = "Establish Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM  yyyy}")]
        public DateTime DateEstablished { get; set; }

        [Display(Name = "Max Capacity")]
        public int Capacity { get; set; }

        public List<string> CEOs { get; set; }
    }
}