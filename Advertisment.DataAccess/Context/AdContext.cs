using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
            //todo later move connection string to web.config
            Database.CreateIfNotExists();
        }
    }

    //internal sealed class DataContextConfiguration : DbMigrationsConfiguration<AdContext>
    //{
    //    public DataContextConfiguration()
    //    {
    //        AutomaticMigrationsEnabled = true;
    //        //AutomaticMigrationDataLossAllowed = true;
    //        //ContextKey = "DataContext";
    //    }
    //}
}
