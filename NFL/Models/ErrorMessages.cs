using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFL.Models
{
    public class ErrorMessages
    {
        //Email
        public const string AtLeastOneEmail = "Enter at Least One Email Address";
        public const string SelectEmailType = "Select Email type";

        //Phone
        public const string AtLeastOnePhone = "Enter at Least One phone number";
        public const string SelectPhoneType = "Select phone number type";

        //Fax
        public const string SelectFaxType = "Select Fax type";

        //City
        public const string InvalidLocation = "Invalid City, State, or Zip Code";


        //Player Not found
        public const string PlayerNotFound = "Player with Id = playerId not found in our database";


        //Insert Stadium name
        //public const string NoStadiumName = "Please insert stadium name";
        public const string NotCorrectStadiumName = "Stadium name can not be empty, it should contain upper/lower case letters [a-z], spaces, and maybe '-' character.";
    }
}
