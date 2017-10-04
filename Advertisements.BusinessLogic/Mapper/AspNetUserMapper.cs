using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertisements.DataAccess.Entities;
using Advertisements.DTO.Models;
namespace Advertisements.BusinessLogic.Mapper
{
    public class AspNetUserMapper : BaseMapper
    {
        protected override IDTO GetDTO(IEntity input)
        {
            var entity = input as ApplicationUser;

            return new AspNetUsersDTO
            {
                Id = entity.Id,
                Email = entity.Email,
                UserName = entity.UserName
            };
        }

        protected override IEntity GetEntity(IDTO dto)
        {
            var aspNetUserDTO = dto as AspNetUsersDTO;

            return new ApplicationUser
            {
                Id = aspNetUserDTO.Id,
                Email = aspNetUserDTO.Email,
                UserName = aspNetUserDTO.UserName
            };
        }
    }
}
