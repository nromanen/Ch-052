using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertisements.DTO.Models
{
    public class AdvertisementUsersDTO
    {
        public string Id;
        public string UserName;

        public AdvertisementUsersDTO() { }
        public AdvertisementUsersDTO(string id, string userName)
        {
            this.Id = id;
            this.UserName = userName;
        }
    }
}
