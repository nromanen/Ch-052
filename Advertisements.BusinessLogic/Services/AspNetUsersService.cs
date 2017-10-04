using System.Linq;
using Advertisements.DTO.Models;
using Advertisements.DataAccess.Repositories;
using Advertisements.DataAccess.Entities;
using Advertisements.BusinessLogic.Mapper;
using System.Collections.Generic;

namespace Advertisements.BusinessLogic.Services
{
    public class AspNetUsersService : IUserService<AspNetUsersDTO>
    {
        private readonly IUOWFactory _uowfactory;
        private readonly BaseMapper _mapper;
        public AspNetUsersService(IUOWFactory uowfactory)
        {
            _uowfactory = uowfactory;
            _mapper = new AspNetUserMapper();
        }

        public void Create(AspNetUsersDTO item)
        {
            ApplicationUser ApplicationUser;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<ApplicationUser>();

                ApplicationUser = _mapper.Map(item) as ApplicationUser;

                repo.Create(ApplicationUser);
            }
        }

        public void Delete(string id)
        {
            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<ApplicationUser>();
                repo.Delete(id);
                uow.BeginTransaction();
                uow.Commit();
            }
        }

        public AspNetUsersDTO Get(string id)
        {
            ApplicationUser ApplicationUser;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<ApplicationUser>();
                ApplicationUser = repo.Get(id);
            }
            return _mapper.Map(ApplicationUser) as AspNetUsersDTO;
        }

        public IEnumerable<AspNetUsersDTO> GetAll()
        {
            IEnumerable<ApplicationUser> appUsers;
            List<AspNetUsersDTO> usersDtos = new List<AspNetUsersDTO>();
            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<ApplicationUser>();

                appUsers = repo.GetAll();
            }
            foreach (var element in appUsers)
            {
                usersDtos.Add(_mapper.Map(element) as AspNetUsersDTO);
            }

            return usersDtos;
        }

        public void Update(AspNetUsersDTO item)
        {
            ApplicationUser ApplicationUser = _mapper.Map(item) as ApplicationUser;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<ApplicationUser>();
                repo.Update(ApplicationUser);
                uow.BeginTransaction();
                uow.Commit();
            }
        }
    }
}

