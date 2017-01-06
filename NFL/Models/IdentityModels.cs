using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NFL.Models.Players_Information;
using NFL.Models.Player.Players_Information;


namespace NFL.Models.Player
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




        //Stadiums
       // public DbSet<Stadium> Stadium { get; set; }
    }

    

}

