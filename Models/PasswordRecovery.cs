using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AD.Models
{
    public class PasswordRecovery
    {
        [Key, ForeignKey("User")]
        public int UserId { get; set; }

        public string AccessHash { get; set; }

        public DateTime Expires { get; set; }

        public virtual User User { get; set; }

    }
}