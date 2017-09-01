using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertisements.DTO.Models
{
    public class TypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public TypeDTO() { }
        public TypeDTO(int _id, string _name) { this.Id = _id; this.Name = _name; }
    }
}
