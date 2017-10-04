using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertisements.DataAccess.Entities;
using Advertisements.BusinessLogic.Mapper;

namespace Advertisements.DTO.Models
{
    public class AdvertisementDTO: IDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<ResourceDTO> Resources { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string ApplicationUserId { get; set; }

        public int CategoryId { get; set; }

        public int TypeId { get; set; }
    }
}
