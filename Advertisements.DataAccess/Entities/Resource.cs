using System.ComponentModel.DataAnnotations.Schema;

namespace Advertisements.DataAccess.Entities
{
    public class Resource : IEntity
    {
        public bool IsDeleted { get; set; }

        public int Id { get; set; }

        public string Url { get; set; }

        [ForeignKey("Advertisement")]
        public int AdvertisementId { get; set; }

        public virtual Advertisement Advertisement { get; set; }
    }
}