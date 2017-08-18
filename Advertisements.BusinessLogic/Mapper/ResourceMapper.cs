using Advertisements.DataAccess.Entities;
using Advertisements.DTO.Models;
using EmitMapper;
using EmitMapper.MappingConfiguration;
using System.Collections.Generic;
using System.Linq;

namespace Advertisements.BusinessLogic.Mapper
{
    public static class ResourceMapper
    {

        public static ObjectsMapper<ResourceDTO, Resource> CreateResource()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<ResourceDTO, Resource>(new DefaultMapConfig().
                ConvertUsing((ResourceDTO source) => new Resource
                {
                    Id = source.Id,
                    Url = source.Url,
                    AdvertisementId = source.AdvertisementId
                }));

            return mapper;
        }

        public static ObjectsMapper<IEnumerable<ResourceDTO>, IEnumerable<Resource>> CreateListResource()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<IEnumerable<ResourceDTO>, IEnumerable<Resource>>(new DefaultMapConfig().
                ConvertUsing<IEnumerable<ResourceDTO>, IEnumerable<Resource>>(a => a.Select(CreateResource().Map)));

            return mapper;
        }

        public static ObjectsMapper<Resource, ResourceDTO> CreateResourceDTO()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<Resource, ResourceDTO>(new DefaultMapConfig().
                ConvertUsing((Resource source) => new ResourceDTO
                {
                    Id = source.Id,
                    Url = source.Url,
                    AdvertisementId = source.AdvertisementId
                }));

            return mapper;
        }

        public static ObjectsMapper<IEnumerable<Resource>, IEnumerable<ResourceDTO>> CreateListAdvertisementDTO()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<IEnumerable<Resource>, IEnumerable<ResourceDTO>>(new DefaultMapConfig().
                ConvertUsing<IEnumerable<Resource>, IEnumerable<ResourceDTO>>(a => a.Select(CreateResourceDTO().Map)));

            return mapper;
        }
    }
}
