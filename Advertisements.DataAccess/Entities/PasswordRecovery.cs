using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Advertisements.DataAccess.Entities
{
    public class PasswordRecovery : IEntity
    {
        [Key, ForeignKey("User")]
        public int Id { get; set; }

        public string AccessHash { get; set; }

        public DateTime Expires { get; set; }

        public virtual User User { get; set; }
    }
}