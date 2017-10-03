using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertisements.DataAccess.Entities;
using Advertisements.DTO.Models;
namespace Advertisements.BusinessLogic.Mapper
{
    public class MyAdvertisementUserMapper : MyBaseMapper
    {
        protected override IDTO GetDTO(IEntity input)
        {
            var entity = input as ApplicationUser;

            return new AdvertisementUsersDTO
            {
                Id = entity.Id,
                UserName = entity.UserName
            };
        }

        protected override IEntity GetEntity(IDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
