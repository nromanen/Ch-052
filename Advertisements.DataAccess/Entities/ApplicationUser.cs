﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Advertisements.DataAccess.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public override string Email { get; set; }
        public bool IsActive { get; set; }
        public virtual List<Advertisement> Advertisements { get; set; }       
        public virtual PasswordRecovery PasswordRecovery { get; set; }      
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string AuthenticationType)
        {
            var useridentity = await manager.CreateIdentityAsync(this,
                AuthenticationType);
            return useridentity;
        }
    }
}
