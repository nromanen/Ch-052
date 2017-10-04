using Advertisements.BusinessLogic.Mapper;
using System;
using System.ComponentModel.DataAnnotations;

namespace Advertisements.DTO.Models
{
    public class AspNetUsersDTO:IDTO
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string UserName { get; set; }


        public AspNetUsersDTO() { }

        public AspNetUsersDTO (string id, string email, string userName)
        {
            Id = id;
            Email = email;            
            UserName = userName;
        }
    }
}
