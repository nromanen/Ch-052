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
    public class ApplicationUser : IdentityUser,IEntity
    {
        public override string Email { get; set; }
        public bool IsActive { get; set; }
<<<<<<< HEAD
        public virtual List<Advertisement> Advertisements { get; set; }
        public virtual PasswordRecovery PasswordRecovery { get; set; }
        public virtual List<Feedback> Feedbacks { get; set; }
=======
        public byte[] Avatar { get; set; }
        public virtual List<Advertisement> Advertisements { get; set; }
        public virtual PasswordRecovery PasswordRecovery { get; set; }
        public virtual List<Feedback> Feedbacks { get; set; }
        public virtual List<Votes> Votes { get; set; }
        public string EmailToken { get; set; }
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
        int IEntity.Id { get; set; }       
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string AuthenticationType)
        {
            var useridentity = await manager.CreateIdentityAsync(this,
                AuthenticationType);
            return useridentity;
        }
<<<<<<< HEAD
=======
        
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
    }
}
