using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Advertisements.DataAccess.Entities
{
    public class Advertisement
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Myfield { get; set; }

        public int Price { get; set; }

        public virtual List<Resource> Resources { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }       
        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [ForeignKey("Type")]
        public int TypeId { get; set; }

        public virtual AdvertisementType Type { get; set; }
    }
}