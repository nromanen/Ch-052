
namespace Advertisements.DTO.Models
{
    public class AdvertisementDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string ApplicationUserId { get; set; }

        public int CategoryId { get; set; }

        public int TypeId { get; set; }
    }
}
