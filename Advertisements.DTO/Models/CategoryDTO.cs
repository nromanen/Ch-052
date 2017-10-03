using Advertisements.BusinessLogic.Mapper;
using System.ComponentModel.DataAnnotations;

namespace Advertisements.DTO.Models
{
    public class CategoryDTO: IDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public CategoryDTO() { }

        public CategoryDTO(int id, string name) { this.Id = id; this.Name = name; }
    }
}
