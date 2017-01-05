﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using NFL.Models.Players_Information;
using NFL.Models.Special_Validations;

namespace NFL.Models.Player
{
    [Serializable()]
    public class ViewModelProfile
    {

        //Profile
        //Personal Information

        public  PersonalInformation personalInformation { get; set; }

        //Address
        public  Address Address1 { get; set; }


        [XmlIgnore]
        public  List<string> States { get; set; }




        //Contact information
        [EmailValidation]
        public  Email[] Emails { get; set; }

        [PhoneValidation]
        public  Phone[]  Phones { get; set; }


        public  Fax[] Faxes { get; set; }

    }

    
    
}
