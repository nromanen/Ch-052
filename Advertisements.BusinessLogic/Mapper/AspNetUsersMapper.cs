using Advertisements.DataAccess.Entities;
using Advertisements.DTO.Models;
using EmitMapper;
using EmitMapper.MappingConfiguration;
using System.Collections.Generic;
using System.Linq;

namespace Advertisements.BusinessLogic.Mapper
{
    public static class AspNetUsersMapper
    {

        public static ObjectsMapper<AspNetUsersDTO, ApplicationUser> CreateAspNetUsers()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<AspNetUsersDTO, ApplicationUser>(new DefaultMapConfig().
                ConvertUsing((AspNetUsersDTO source) => new ApplicationUser
                {
                    Id = source.Id,
                    Email = source.Email,
                    UserName = source.UserName
                }));
            return mapper;
        }

        public static ObjectsMapper<IEnumerable<AspNetUsersDTO>, IEnumerable<ApplicationUser>> CreateListAspNetUsers()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<IEnumerable<AspNetUsersDTO>, IEnumerable<ApplicationUser>>(new DefaultMapConfig().
                ConvertUsing<IEnumerable<AspNetUsersDTO>, IEnumerable<ApplicationUser>>(a => a.Select(CreateAspNetUsers().Map)));

            return mapper;
        }

        public static ObjectsMapper<ApplicationUser, AspNetUsersDTO> CreateAspNetUsersDTO()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<ApplicationUser, AspNetUsersDTO>(new DefaultMapConfig().
                ConvertUsing((ApplicationUser source) => new AspNetUsersDTO
                {
                    Id = source.Id,
                    Email = source.Email,
                    UserName = source.UserName
                }));

            return mapper;
        }

        public static ObjectsMapper<IEnumerable<ApplicationUser>, IEnumerable<AspNetUsersDTO>> CreateListAspNetUsersDTO()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<IEnumerable<ApplicationUser>, IEnumerable<AspNetUsersDTO>>(new DefaultMapConfig().
                ConvertUsing<IEnumerable<ApplicationUser>, IEnumerable<AspNetUsersDTO>>(a => a.Select(CreateAspNetUsersDTO().Map)));

            return mapper;
        }
    }
}
