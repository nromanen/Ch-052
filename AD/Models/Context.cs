using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AD.Models
{
    public class Context :  DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public Context ()
        {
            Database.CreateIfNotExists();
        }
    }
}