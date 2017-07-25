using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Advertisement.DataAccess.Entities
{
    public class Advert
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Myfield { get; set; }

        public int Price { get; set; }

        public virtual List<Resource> Resources { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [ForeignKey("Type")]
        public int TypeId { get; set; }

        public virtual AdvType Type{ get; set; }
    }
}