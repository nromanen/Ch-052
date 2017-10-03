using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertisements.DataAccess.Entities;
using Advertisements.DTO.Models;
namespace Advertisements.BusinessLogic.Mapper
{
    public class MyTypeMapper : MyBaseMapper
    {
        protected override IDTO GetDTO(IEntity input)
        {
            var entity = input as AdvertisementType;

            return new TypeDTO
            {
                Id = entity.Id,
                Name = entity.Name
            };

        }

        protected override IEntity GetEntity(IDTO dto)
        {
            var typeDTO = dto as TypeDTO;

            return new AdvertisementType
            {
                Id = typeDTO.Id,
                Name = typeDTO.Name
            };
        }
    }
}
