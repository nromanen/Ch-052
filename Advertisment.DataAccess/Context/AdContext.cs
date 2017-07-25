using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Advertisement.DataAccess.Entities;
namespace Advertisement.DataAccess.Context
{
    public class AdContext: DbContext
    {
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<Resource> Resources { get; set; }
        //public DbSet<AdvType> Types { get; set; }
        public DbSet<Advert> Advertisements { get; set; }
        //public DbSet<PasswordRecovery> PasswordRecoveries { get; set; }

        public AdContext(): base("ConnectionDB")
        {
            Database.CreateIfNotExists();
        }
    }
}
