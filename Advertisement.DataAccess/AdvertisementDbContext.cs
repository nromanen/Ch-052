using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertisement.DataAccess.Entities;

namespace Advertisement.DataAccess
{
    public class AdvertisementDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<AdvertType> Types { get; set; }
        public DbSet<Advert> Advertisements { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<PasswordRecovery> PasswordRecoveries { get; set; }
    }
}
