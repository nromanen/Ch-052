using Advertisements.DataAccess.Entities;
using Advertisements.DTO.Models;
using EmitMapper;
using EmitMapper.MappingConfiguration;
using System.Collections.Generic;
using System.Linq;

namespace Advertisements.BusinessLogic.Mapper
{
    public static class AdvertisementMapper
    {

        public static ObjectsMapper<AdvertisementDTO, Advertisement> CreateAdvertisement()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<AdvertisementDTO, Advertisement>(new DefaultMapConfig().
                ConvertUsing((AdvertisementDTO source) => new Advertisement
                {
                    Id = source.Id,
                    Title = source.Title,
                    Description = source.Description,
                    Price = source.Price
                }));

            return mapper;
        }

        public static ObjectsMapper<IEnumerable<AdvertisementDTO>, IEnumerable<Advertisement>> CreateListAdvertisement()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<IEnumerable<AdvertisementDTO>, IEnumerable<Advertisement>>(new DefaultMapConfig().
                ConvertUsing<IEnumerable<AdvertisementDTO>, IEnumerable<Advertisement>>(a => a.Select(CreateAdvertisement().Map)));

            return mapper;
        }

        public static ObjectsMapper<Advertisement, AdvertisementDTO> CreateAdvertisementDTO()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<Advertisement, AdvertisementDTO>(new DefaultMapConfig().
                ConvertUsing((Advertisement source) => new AdvertisementDTO
                {
                    Id = source.Id,
                    Title = source.Title,
                    Description = source.Description,
                    Price = source.Price
                }));

            return mapper;
        }

        public static ObjectsMapper<IEnumerable<Advertisement>, IEnumerable<AdvertisementDTO>> CreateListAdvertisementDTO()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<IEnumerable<Advertisement>, IEnumerable<AdvertisementDTO>>(new DefaultMapConfig().
                ConvertUsing<IEnumerable<Advertisement>, IEnumerable<AdvertisementDTO>>(a => a.Select(CreateAdvertisementDTO().Map)));

            return mapper;
        }
    }
}
