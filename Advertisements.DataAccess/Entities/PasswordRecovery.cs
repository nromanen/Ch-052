using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Advertisements.DataAccess.Entities
{
    public class PasswordRecovery : IEntity
    {
        [Key, ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }

        public int Id { get; set; }

        public string AccessHash { get; set; }

        public DateTime Expires { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}