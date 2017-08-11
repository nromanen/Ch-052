namespace Advertisements.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Advertisements.DataAccess.Entities;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<Advertisements.DataAccess.Context.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Advertisements.DataAccess.Context.ApplicationDbContext context)
        {
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
