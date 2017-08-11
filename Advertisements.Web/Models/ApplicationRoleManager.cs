using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;
using Advertisements.DataAccess.Context;
using System.Threading.Tasks;
namespace Advertisements.Web.Models
{
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole, string> store) : base(store)
        {
            
        }
        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            var appRoleManager = new ApplicationRoleManager(new RoleStore<IdentityRole>(context.Get<ApplicationDbContext>()));
            CheckIfRolesExist(appRoleManager);
            
            return appRoleManager;
        }
        public static void CheckIfRolesExist(ApplicationRoleManager manager)
        {
            if (!manager.RoleExists("Admin"))
            {
                manager.Create(new IdentityRole("Admin"));
                
            }
            if (!manager.RoleExists("Customer"))
            {
                manager.Create(new IdentityRole("Customer"));
            }
        }
    }
}