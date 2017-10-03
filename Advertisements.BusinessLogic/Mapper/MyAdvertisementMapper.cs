using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertisements.DataAccess.Entities;
using Advertisements.DTO.Models;

namespace Advertisements.BusinessLogic.Mapper
{
    public class MyAdvertisementMapper : MyBaseMapper
    {
        private MyBaseMapper _resourceMapper = new MyResourceMapper();
        protected override IDTO GetDTO(IEntity input)
        {
            var entity = input as Advertisement;
            var resources = _resourceMapper.MapCollection(entity.Resources);
            List<ResourceDTO> temp = new List<ResourceDTO>();
            foreach (var element in resources)
            {
                temp.Add(element as ResourceDTO);
            }
            return new AdvertisementDTO
            {
                ApplicationUserId = entity.ApplicationUserId,
                Id = entity.Id,
                CategoryId = entity.CategoryId,
                Description = entity.Description,
                Price = entity.Price,
                Resources = temp,
                Title = entity.Title,
                TypeId = entity.TypeId
            };
        }

        protected override IEntity GetEntity(IDTO input)
        {
            var dto = input as AdvertisementDTO;
            var resources = _resourceMapper.MapCollection(dto.Resources);
            List<Resource> resultResources = new List<Resource>();
            foreach (var element in resources)
            {
                var res = element as Resource;
                res.AdvertisementId = dto.Id;
                resultResources.Add(res);
            }           
            return new Advertisement
            {
                ApplicationUserId = dto.ApplicationUserId,
                Id = dto.Id,
                CategoryId = dto.CategoryId,
                Description = dto.Description,
                Price = dto.Price,
                Resources = resultResources,
                Title = dto.Title,
                TypeId = dto.TypeId
                
            };
        }
    }
}
