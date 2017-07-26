using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Advertisement.DataAccess.Entities
{
    public class Feedback
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int AgreeCount { get; set; }

        public int DisagreeCount { get; set; }

        public DateTime CreationTime { get; set; }

        [ForeignKey("Advert")]
        public int AdvertId { get; set; }

        public virtual User User { get; set; }

        public virtual Advert Advert { get; set; }
    }
}
