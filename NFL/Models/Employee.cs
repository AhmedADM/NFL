using NFL.Models.Experiences;
using NFL.Models.Profile;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NFL.Models.Employees
{
    public class Employee
    {
        public int Id { get; set; }

        public PersonalInformation personalInformation { get; set; }

        public ContactInformation contactInformation { get; set; }


        //public List<Education_History> Educations { get; set; }

        public List<Experience> WorkExperience { get; set; }

    }
}