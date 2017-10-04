using System.Linq;
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
        private readonly BaseMapper _mapper;
        public AdvertisementUsersService(IUOWFactory factory)
        {
            this._ouwfactory = factory;
            this._mapper = new AdvertisementUserMapper();
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
            return _mapper.Map(user) as AdvertisementUsersDTO;
        }

        public IEnumerable<AdvertisementUsersDTO> GetAll()
        {
            IEnumerable<ApplicationUser> users;

            using (var uow = this._ouwfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<ApplicationUser>();
                users = repo.GetAll();
            }
            return this.UnboxAdvUsers(_mapper.MapCollection(users));
        }

        public void Update(AdvertisementUsersDTO item)
        {
            throw new NotImplementedException();
        }
        private IEnumerable<AdvertisementUsersDTO> UnboxAdvUsers(IEnumerable<IDTO> dtos)
        {
            List<AdvertisementUsersDTO> advUsersResult = new List<AdvertisementUsersDTO>();

            foreach (var element in dtos)
            {
                advUsersResult.Add(element as AdvertisementUsersDTO);
            }
            return advUsersResult;
        }
    }
}
