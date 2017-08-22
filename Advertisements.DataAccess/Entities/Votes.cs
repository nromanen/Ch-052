using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Advertisements.DataAccess.Entities
{
    public class Votes : IEntity
    {
        [Key]
        public int Id { get; set; }

        public bool Agree { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Feedback")]
        public int FeedbackId { get; set; }

        public virtual Feedback Feedback { get; set; }

    }
}
