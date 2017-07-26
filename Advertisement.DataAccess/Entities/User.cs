using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Advertisement.DataAccess.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool Active { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }

        [ForeignKey("PasswordRecovery")]
        public int? PasswordRecoveyId { get; set; }

        public virtual Role Role { get; set; }

        public virtual List<Advert> Advertisements { get; set; }

        public virtual PasswordRecovery PasswordRecovery { get; set; }

        public virtual List<Feedback> Feedbacks { get; set; }
    }
}