using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertisements.DataAccess.Entities;
using Advertisements.DTO.Models;
namespace Advertisements.BusinessLogic.Mapper
{
    public class MyResourceMapper : MyBaseMapper
    {
        protected override IDTO GetDTO(IEntity input)
        {
            var entity = input as Resource;

            return new ResourceDTO
            {
                Id = entity.Id,
                AdvertisementId = entity.AdvertisementId,
                Url = entity.Url
            };
        }

        protected override IEntity GetEntity(IDTO input)
        {
            var dto = input as ResourceDTO;

            return new Resource
            {
                Id = dto.Id,
                AdvertisementId = dto.AdvertisementId,
                Url = dto.Url,
                IsDeleted = false
            };
        }
    }
}
