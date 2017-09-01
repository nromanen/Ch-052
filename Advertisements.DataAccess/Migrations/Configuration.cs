namespace Advertisements.DataAccess.Migrations
{
<<<<<<< HEAD
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Advertisements.DataAccess.Entities;
    using Microsoft.AspNet.Identity.EntityFramework;

=======
    using System.Data.Entity.Migrations;
    using Advertisements.DataAccess.Entities;
    using Microsoft.AspNet.Identity.EntityFramework;
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
    internal sealed class Configuration : DbMigrationsConfiguration<Advertisements.DataAccess.Context.ApplicationDbContext>
    {
        public Configuration()
        {
<<<<<<< HEAD
            AutomaticMigrationsEnabled = true;
=======
            AutomaticMigrationsEnabled = false;
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
        }

        protected override void Seed(Advertisements.DataAccess.Context.ApplicationDbContext context)
        {
<<<<<<< HEAD
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Types.AddOrUpdate(
               x => x.Name,
               new AdvertisementType { Name = "Sale" },
               new AdvertisementType { Name = "Buy" },
               new AdvertisementType { Name = "Exchange" },
               new AdvertisementType { Name = "Present" }
               );
=======
            context.Types.AddOrUpdate(
              x => x.Name,
              new AdvertisementType { Name = "Sale" },
              new AdvertisementType { Name = "Buy" },
              new AdvertisementType { Name = "Exchange" },
              new AdvertisementType { Name = "Present" }
              );
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d

            context.Categories.AddOrUpdate(
            x => x.Name,
            new Category { Name = "education" },
            new Category { Name = "estate" },
            new Category { Name = "repair" }
            );

            context.Roles.AddOrUpdate(
            x => x.Name,
                new IdentityRole { Name = "Admin" },
                new IdentityRole { Name = "Customer" }
                );
        }
    }
}
