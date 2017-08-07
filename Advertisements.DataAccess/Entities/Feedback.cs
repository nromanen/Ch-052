using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual Advertisement Advertisement { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
