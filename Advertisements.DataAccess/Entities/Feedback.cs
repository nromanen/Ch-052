using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Advertisements.DataAccess.Entities
{
    public class Feedback
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int AgreeCount { get; set; }

        public int DisagreeCount { get; set; }

        public DateTime CreationTime { get; set; }

        [ForeignKey("Advertisement")]
        public int AdvertisementId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Advertisement Advertisement { get; set; }
    }
}
