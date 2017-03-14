using NFL.Models.Employees;


namespace NFL.Models.Staff
{
    public class FrontOffice
    {
        public int Id { get; set; }
        public Employee OwnerCEO { get; set; }
        public Employee CEO { get; set; }

        public Employee Precident { get; set; }

        public Employee SpecialAssistence { get; set; }


        //More to add later
    }
}