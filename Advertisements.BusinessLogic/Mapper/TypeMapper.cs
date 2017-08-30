using Advertisements.DataAccess.Entities;
using Advertisements.DTO.Models;
using EmitMapper;
using EmitMapper.MappingConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertisements.BusinessLogic.Mapper
{
    public static class TypeMapper
    {

        public static ObjectsMapper<TypeDTO, AdvertisementType> CreateType()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<TypeDTO, AdvertisementType>(new DefaultMapConfig().
                ConvertUsing((TypeDTO source) => new AdvertisementType { Id = source.Id, Name = source.Name }));

            return mapper;
        }

        public static ObjectsMapper<IEnumerable<TypeDTO>, IEnumerable<AdvertisementType>> CreateListType()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<IEnumerable<TypeDTO>, IEnumerable<AdvertisementType>>(new DefaultMapConfig().
                ConvertUsing<IEnumerable<TypeDTO>, IEnumerable<AdvertisementType>>(a => a.Select(CreateType().Map)));

            return mapper;
        }

        public static ObjectsMapper<AdvertisementType, TypeDTO> CreateTypeDTO()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<AdvertisementType, TypeDTO>(new DefaultMapConfig().
                ConvertUsing((AdvertisementType source) => new TypeDTO { Id = source.Id, Name = source.Name }));

            return mapper;
        }

        public static ObjectsMapper<IEnumerable<AdvertisementType>, IEnumerable<TypeDTO>> CreateListTypeDTO()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<IEnumerable<AdvertisementType>, IEnumerable<TypeDTO>>(new DefaultMapConfig().
                ConvertUsing<IEnumerable<AdvertisementType>, IEnumerable<TypeDTO>>(a => a.Select(CreateTypeDTO().Map)));

            return mapper;
        }
    }
}
