using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AD.Models;

namespace AD
{
    public class AdverseContext :  DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<AdvType> Types { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }


        public AdverseContext ()
        {
            Database.CreateIfNotExists();
        }
    }
}