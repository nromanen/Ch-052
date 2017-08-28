using Advertisements.DataAccess.Entities;
using Advertisements.DTO.Models;
using EmitMapper;
using EmitMapper.MappingConfiguration;
using System.Collections.Generic;
using System.Linq;

namespace Advertisements.BusinessLogic.Mapper
{
    public static class AdvertisementTypeMapper
    {

        public static ObjectsMapper<AdvertisementTypeDTO, AdvertisementType> CreateAdvertisementType()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<AdvertisementTypeDTO, AdvertisementType>(new DefaultMapConfig().
                ConvertUsing((AdvertisementTypeDTO source) => new AdvertisementType
                {
                    Id = source.Id,
                    Name = source.Name
                }));

            return mapper;
        }

        public static ObjectsMapper<IEnumerable<AdvertisementTypeDTO>, IEnumerable<AdvertisementType>> CreateListAdvertisementType()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<IEnumerable<AdvertisementTypeDTO>, IEnumerable<AdvertisementType>>(new DefaultMapConfig().
                ConvertUsing<IEnumerable<AdvertisementTypeDTO>, IEnumerable<AdvertisementType>>(a => a.Select(CreateAdvertisementType().Map)));

            return mapper;
        }

        public static ObjectsMapper<AdvertisementType, AdvertisementTypeDTO> CreateAdvertisementTypeDTO()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<AdvertisementType, AdvertisementTypeDTO>(new DefaultMapConfig().
                ConvertUsing((AdvertisementType source) => new AdvertisementTypeDTO
                {
                    Id = source.Id,
                    Name = source.Name
                }));

            return mapper;
        }

        public static ObjectsMapper<IEnumerable<AdvertisementType>, IEnumerable<AdvertisementTypeDTO>> CreateListAdvertisementTypeDTO()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<IEnumerable<AdvertisementType>, IEnumerable<AdvertisementTypeDTO>>(new DefaultMapConfig().
                ConvertUsing<IEnumerable<AdvertisementType>, IEnumerable<AdvertisementTypeDTO>>(a => a.Select(CreateAdvertisementTypeDTO().Map)));

            return mapper;
        }
    }
}
