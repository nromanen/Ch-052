using Advertisements.DataAccess.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertisements.DataAccess.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Resource> Resources { get; set; }
        public IDbSet<AdvertisementType> Types { get; set; }
        public IDbSet<Advertisement> Advertisements { get; set; }
        public IDbSet<PasswordRecovery> PasswordRecoveries { get; set; }
        public IDbSet<Feedback> Feedbacks { get; set; }
<<<<<<< HEAD
        public ApplicationDbContext()
            : base("Connection", throwIfV1Schema: false)
        {
=======
        public IDbSet<Votes> VotedUsers { get; set; }

        public ApplicationDbContext()
            : base("Connection", throwIfV1Schema: false)
        {
            this.Configuration.LazyLoadingEnabled = false;
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
