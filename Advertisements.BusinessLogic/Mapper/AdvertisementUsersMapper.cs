using Advertisements.DataAccess.Entities;
using Advertisements.DTO.Models;
using EmitMapper;
using EmitMapper.MappingConfiguration;
using System.Collections.Generic;
using System.Linq;

namespace Advertisements.BusinessLogic.Mapper
{
    public static class AdvertisementUsersMapper
    {
        public static ObjectsMapper<ApplicationUser,AdvertisementUsersDTO> GetAdvertisementUsersDTO()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<ApplicationUser, AdvertisementUsersDTO>(new DefaultMapConfig().
                ConvertUsing((ApplicationUser source) => new AdvertisementUsersDTO
                {
                    Id = source.Id,
                    UserName = source.UserName                   
                }));

            return mapper;
        }

        public static ObjectsMapper<IEnumerable<ApplicationUser>, IEnumerable<AdvertisementUsersDTO>> CreateListAdvertisementusersDTO()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<IEnumerable<ApplicationUser>, IEnumerable<AdvertisementUsersDTO>>(new DefaultMapConfig().
                ConvertUsing<IEnumerable<ApplicationUser>, IEnumerable<AdvertisementUsersDTO>>((appUsers) => appUsers.Select(GetAdvertisementUsersDTO().Map)));

            return mapper;
        }
    }
}
