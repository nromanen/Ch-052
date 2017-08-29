using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertisements.DTO.Models
{
    public class PasswordRecoveryDTO
    {
        public string ApplicationUserId { get; set; }

        public int Id { get; set; }

        public string AccessHash { get; set; }

        public DateTime Expires { get; set; }

    }
}
