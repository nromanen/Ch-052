using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Advertisement.DataAccess.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<Advert> Advertisements { get; set; }
    }
}