using NFL.Models;
using NFL.Models.Employees;
using NFL.Models.Experiences;
using NFL.Models.Profile;
using NFL.Models.Staff;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NFL.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            //AddStaff();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public void AddStaff()
        {
            var employee1 = new Employee()
            {
                personalInformation = new PersonalInformation()
                {
                    FirstName = "Garry",
                    LastName = "Kubiak",
                    BirthDate = new DateTime(1950, 05, 01),
                    Gender = "Male"
                },
                contactInformation = new ContactInformation()
                {
                    Emails = new List<Email>
                    {
                        new Email {Type = "work", email = "KK@Broncos.com" }
                    },

                    PhoneNumbers = new List<Phone>
                    {
                        new Phone {Type = "Personal", Number = "7206667231" }
                    }
                },

                WorkExperience = new List<Experience>
                {
                    new Experience()
                    {
                        Organization = "Ravens",
                        DateFrom = new DateTime(2013,01,01),
                        Role = "Offensive Coordinator",
                        Description = "Ravense Offensive Coordinator"
                    }
                }
            };



            var employee2 = new Employee()
            {
                personalInformation = new PersonalInformation()
                {
                    FirstName = "Wade",
                    LastName = "Phillips",
                    BirthDate = new DateTime(1950, 05, 01),
                    Gender = "Male"
                },
                contactInformation = new ContactInformation()
                {
                    Emails = new List<Email>
                    {
                        new Email {Type = "work", email = "WP@Broncos.com" }
                    },

                    PhoneNumbers = new List<Phone>
                    {
                        new Phone {Type = "Personal", Number = "7206697299" }
                    }
                },

                WorkExperience = new List<Experience>
                {
                    new Experience()
                    {
                        Organization = "Texans",
                        DateFrom = new DateTime(2012,01,01),
                        Role = "Defensive Coordinator",
                        Description = "Texans Defensive Coordinator"
                    }
                }
            };




            var employee3 = new Employee()
            {
                personalInformation = new PersonalInformation()
                {
                    FirstName = "Rick",
                    LastName = "Dennison",
                    BirthDate = new DateTime(1957, 05, 01),
                    Gender = "Male"
                },
                contactInformation = new ContactInformation()
                {
                    Emails = new List<Email>
                    {
                        new Email {Type = "work", email = "RD@Broncos.com" }
                    },

                    PhoneNumbers = new List<Phone>
                    {
                        new Phone {Type = "Personal", Number = "7216697299" }
                    }
                },

                WorkExperience = new List<Experience>
                {
                    new Experience()
                    {
                        Organization = "Bengals",
                        DateFrom = new DateTime(2014,01,01),
                        Role = "Quarterback Coach",
                        Description = "Bengals Quarterback Coach"
                    }
                }
            };


            var employee4 = new Employee()
            {
                personalInformation = new PersonalInformation()
                {
                    FirstName = "John",
                    LastName = "Elway",
                    BirthDate = new DateTime(1944, 05, 01),
                    Gender = "Male"
                },
                contactInformation = new ContactInformation()
                {
                    Emails = new List<Email>
                    {
                        new Email {Type = "work", email = "JEL@Broncos.com" }
                    },

                    PhoneNumbers = new List<Phone>
                    {
                        new Phone {Type = "Personal", Number = "7206691184" }
                    }
                },

                WorkExperience = new List<Experience>
                {
                    new Experience()
                    {
                        Organization = "Broncos",
                        DateFrom = new DateTime(1980,01,01),
                        Role = "Quarterback",
                        Description = "Broncos Quarterback"
                    }
                }
            };
            var staff = new Staff()
            {

                frontOffice = new FrontOffice()
                {
                    CEO = employee4,
                    OwnerCEO = employee4,
                    Precident = employee4,
                    SpecialAssistence = employee4,
                },

                offensiveCoaches = new OffensiveCoaches()
                {
                    OffensiveCoordinator = employee1,
                    QuarterbackCoach = employee3
                }
            };



            db.Entry(staff).State = EntityState.Added;

            db.SaveChanges();

        }
    }
}