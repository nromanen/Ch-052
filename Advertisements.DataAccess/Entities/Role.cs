using System.Collections.Generic;

namespace Advertisements.DataAccess.Entities
{
    public class Role : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<User> Users { get; set; }
    }
}