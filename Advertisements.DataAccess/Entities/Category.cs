using System.Collections.Generic;

namespace Advertisements.DataAccess.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<Advertisement> Advertisements { get; set; }
    }
}