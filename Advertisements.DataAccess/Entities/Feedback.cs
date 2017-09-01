using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
<<<<<<< HEAD
=======
using System.Runtime.Serialization;
using System.Collections.Generic;
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d

namespace Advertisements.DataAccess.Entities
{
    public class Feedback : IEntity
    {
        public int Id { get; set; }

        public string Text { get; set; }

        [DataType(DataType.Currency)]
        public int AgreeCount { get; set; }

        [DataType(DataType.Currency)]
        public int DisagreeCount { get; set; }

        public DateTime CreationTime { get; set; }

        [ForeignKey("Advertisement")]
        public int AdvertisementId { get; set; }

<<<<<<< HEAD
        public virtual ApplicationUser ApplicationUser { get; set; }

=======
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual List<Votes> Votes { get; set; }

>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
        public virtual Advertisement Advertisement { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
