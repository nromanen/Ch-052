namespace Advertisements.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    using Advertisements.DataAccess.Entities;
    using Microsoft.AspNet.Identity.EntityFramework;
    internal sealed class Configuration : DbMigrationsConfiguration<Advertisements.DataAccess.Context.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Advertisements.DataAccess.Context.ApplicationDbContext context)
        {
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
