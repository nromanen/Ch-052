using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AD.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<Advertisement> Advertisements { get; set; }
    }
}