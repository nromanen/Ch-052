using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Advertisement.DataAccess.Entities
{
    public class Resource 
    {
        public int Id { get; set; }

        public string Url { get; set; }

        [ForeignKey("Advertisement")]
        public int AdvertisementId { get; set; }

        public virtual Advert Advertisement { get; set; }
    }
}