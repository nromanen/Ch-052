using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Advertisements.DataAccess.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace Advertisements.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public override string Email { get; set; }
        public bool ConfirmedEmail { get; set; }
        public bool IsActive { get; set; }
        public virtual List<Advertisement> Advertisements { get; set; }
        public PasswordRecovery PasswordRecovery { get; set; }        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string AuthenticationType)
        {
            var useridentity = await manager.CreateIdentityAsync(this,
                AuthenticationType);
            return useridentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {        
       
        public ApplicationDbContext()
            : base("ConnectDB", throwIfV1Schema: false)
        {
            
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}