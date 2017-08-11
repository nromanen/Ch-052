using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertisements.DTO.Models
{
    public class AdvertisementDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public AdvertisementDTO() { }

        public AdvertisementDTO(int id, string title, string description, int price)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.Price = price;
        }
    }
}
