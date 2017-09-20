using Advertisements.DTO.Models;
using Advertisements.DataAccess.Repositories;
using Advertisements.DataAccess.Entities;
using Advertisements.BusinessLogic.Mapper;
using System.Collections.Generic;
using System;

namespace Advertisements.BusinessLogic.Services
{
    public class AdvertisementUsersService : IUserService<AdvertisementUsersDTO>
    {
        private readonly IUOWFactory _ouwfactory;

        public AdvertisementUsersService(IUOWFactory factory)
        {
            this._ouwfactory = factory;
        }

        public void Create(AdvertisementUsersDTO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public AdvertisementUsersDTO Get(string id)
        {
            ApplicationUser user;

            using (var uow = this._ouwfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<ApplicationUser>();
                user = repo.Get(id);
            }
            return AdvertisementUsersMapper.GetAdvertisementUsersDTO().Map(user);
        }

        public IEnumerable<AdvertisementUsersDTO> GetAll()
        {
            IEnumerable<ApplicationUser> users;

            using (var uow = this._ouwfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<ApplicationUser>();
                users = repo.GetAll();
            }
            return AdvertisementUsersMapper.CreateListAdvertisementusersDTO().Map(users);
        }

        public void Update(AdvertisementUsersDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
