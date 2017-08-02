using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Advertisements.DataAccess.Entities
{
    public class PasswordRecovery
    {
        [Key, ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }

        public string AccessHash { get; set; }

        public DateTime Expires { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        
    }
}