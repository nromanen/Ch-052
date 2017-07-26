using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Advertisements.DataAccess.Entities;

namespace Advertisements.DataAccess.Context
{
    public class AdvertisementsContext: DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<AdvertisementType> Types { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<PasswordRecovery> PasswordRecoveries { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        public AdvertisementsContext(): base("ConnectDB")
        {
            //todo later move connection string to web.config
            Database.CreateIfNotExists();
        }
    }

    //internal sealed class DataContextConfiguration : DbMigrationsConfiguration<AdvertisementsContext>
    //{
    //    public DataContextConfiguration()
    //    {
    //        AutomaticMigrationsEnabled = true;
    //        AutomaticMigrationDataLossAllowed = true;
    //        ContextKey = "DataContext";
    //    }
    //}
}
