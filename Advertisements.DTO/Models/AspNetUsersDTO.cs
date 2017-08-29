using System;
using System.ComponentModel.DataAnnotations;

namespace Advertisements.DTO.Models
{
    public class AspNetUsersDTO
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public bool IsActive { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTime LockoutEndDateUtc { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        public string UserName { get; set; }

        public byte[] Avatar { get; set; }

        public AspNetUsersDTO() { }

        public AspNetUsersDTO (string id, string email, bool emailConfirmed, bool isActive, string passwordHash, string securityStamp, string phoneNumber,
                bool phoneNumberConfirmed, bool twoFactorEnabled, DateTime lockoutEndDateUtc, bool lockoutEnabled, int accessFailedCount, string userName,
                byte[] avatar)
        {
            Id = id;
            Email = email;
            EmailConfirmed = emailConfirmed;
            IsActive = isActive;
            PasswordHash = passwordHash;
            SecurityStamp = securityStamp;
            PhoneNumber = phoneNumber;
            PhoneNumberConfirmed = phoneNumberConfirmed;
            TwoFactorEnabled = twoFactorEnabled;
            LockoutEndDateUtc = lockoutEndDateUtc;
            LockoutEnabled = lockoutEnabled;
            AccessFailedCount = accessFailedCount;
            UserName = userName;
            Avatar = avatar;
        }
    }
}
