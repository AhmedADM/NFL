using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NFL.Models.Players_Information;
using NFL.Models.Player.Players_Information;
using NFL.Models.Addresses;
using NFL.Models;
using NFL.Models.Player;
using NFL.Models.Profile;
using NFL.Models.Experiences;
using NFL.Models.Employees;
using NFL.Models.Staff;

namespace NFL
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }



    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Stadium>().ToTable("Stadium");
        }


        //Player Information
        public DbSet<Player> Player { get; set; }



        //Address
        public DbSet<Location> Cities { get; set; }
        public DbSet<Address> Addresses { get; set; }



        //Personal Information
        public DbSet<PersonalInformation> PersonalInformation { get; set; }

        //Contact Information
        public DbSet<ContactInformation> ContactInformation { get; set; }
        public DbSet<Email> Email { get; set; }
        public DbSet<Phone> Phone { get; set; }
        public DbSet<Fax> Fax { get; set; }


        //Other Information

        public DbSet<Information> Information { get; set; }
        public DbSet<Education_History> Education { get; set; }
        public DbSet<Measurments> Measurments { get; set; }

        public DbSet<MainPosition> MainPosition { get; set; }



        //partyAddress
        public DbSet<partyAddress> PartyAddress { get; set; }
        //Stadiums
        public DbSet<Stadium> Stadium { get; set; }



        //Experience

        public DbSet<Experience> Experience { get; set; }


        //Employee

       public DbSet<Employee> Employee { get; set; }


        //Staff

        public DbSet<Staff> Staff { get; set; }
        public DbSet<FrontOffice> FrontOffice { get; set; }
        public DbSet<OffensiveCoaches> OffensiveCoaches { get; set; }

        //And more to add later





    }

   


}

