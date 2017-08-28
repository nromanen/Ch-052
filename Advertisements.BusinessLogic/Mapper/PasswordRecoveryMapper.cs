using Advertisements.DataAccess.Entities;
using Advertisements.DTO.Models;
using EmitMapper;
using EmitMapper.MappingConfiguration;
using System.Collections.Generic;
using System.Linq;

namespace Advertisements.BusinessLogic.Mapper
{
    public static class PasswordRecoveryMapper
    {

        public static ObjectsMapper<PasswordRecoveryDTO, PasswordRecovery> CreatePasswordRecovery()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<PasswordRecoveryDTO, PasswordRecovery>(new DefaultMapConfig().
                ConvertUsing((PasswordRecoveryDTO source) => new PasswordRecovery
                {
                    ApplicationUserId = source.ApplicationUserId,
                    Id = source.Id,
                    AccessHash = source.AccessHash,
                    Expires = source.Expires
                }));

            return mapper;
        }

        public static ObjectsMapper<IEnumerable<PasswordRecoveryDTO>, IEnumerable<PasswordRecovery>> CreateListPasswordRecovery()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<IEnumerable<PasswordRecoveryDTO>, IEnumerable<PasswordRecovery>>(new DefaultMapConfig().
                ConvertUsing<IEnumerable<PasswordRecoveryDTO>, IEnumerable<PasswordRecovery>>(a => a.Select(CreatePasswordRecovery().Map)));

            return mapper;
        }

        public static ObjectsMapper<PasswordRecovery, PasswordRecoveryDTO> CreatePasswordRecoveryDTO()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<PasswordRecovery, PasswordRecoveryDTO>(new DefaultMapConfig().
                ConvertUsing((PasswordRecovery source) => new PasswordRecoveryDTO
                {
                    ApplicationUserId = source.ApplicationUserId,
                    Id = source.Id,
                    AccessHash = source.AccessHash,
                    Expires = source.Expires
                }));

            return mapper;
        }

        public static ObjectsMapper<IEnumerable<PasswordRecovery>, IEnumerable<PasswordRecoveryDTO>> CreateListAdvertisementDTO()
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<IEnumerable<PasswordRecovery>, IEnumerable<PasswordRecoveryDTO>>(new DefaultMapConfig().
                ConvertUsing<IEnumerable<PasswordRecovery>, IEnumerable<PasswordRecoveryDTO>>(a => a.Select(CreatePasswordRecoveryDTO().Map)));

            return mapper;
        }
    }
}
