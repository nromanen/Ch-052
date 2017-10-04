using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertisements.DataAccess.Entities;
using Advertisements.DTO.Models;
namespace Advertisements.BusinessLogic.Mapper
{
    public class CategoryMapper : BaseMapper
    {
        protected override IDTO GetDTO(IEntity input)
        {
            var entity = input as Category;

            return new CategoryDTO
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        protected override IEntity GetEntity(IDTO dto)
        {
            var categoryDTO = dto as CategoryDTO;

            return new Category
            {
                Id = categoryDTO.Id,
                Name = categoryDTO.Name,
                IsDeleted = false
            };
        }
    }
}
