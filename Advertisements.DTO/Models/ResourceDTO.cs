using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertisements.DTO.Models
{
    public class ResourceDTO
    {
        public int Id { get; set; }

        public string Url { get; set; }
        
        public int AdvertisementId { get; set; }
    }
}
