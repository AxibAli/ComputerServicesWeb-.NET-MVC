using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ComputerServicesWeb.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public bool? IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UserPicturePath { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationRole: IdentityRole
    {
        public ApplicationRole():base()
        {

        }

        public ApplicationRole(string roleName):base(roleName)
        {

        }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(): base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<IdentityUserRole> UserRoles { get; set; }
        public DbSet<IdentityUserClaim> Claims { get; set; }
        public DbSet<IdentityUserLogin> Logins { get; set; }
        public DbSet<UsedMachineModels> usedMachines { get; set; }
        public DbSet<ServicesModel> services { get; set; }

    }
}