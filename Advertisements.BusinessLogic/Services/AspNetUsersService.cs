using System.Linq;
using Advertisements.DTO.Models;
using Advertisements.DataAccess.Repositories;
using Advertisements.DataAccess.Entities;
using Advertisements.BusinessLogic.Mapper;
using System.Collections.Generic;

namespace Advertisements.BusinessLogic.Services
{
    public class AspNetUsersService : IService<AspNetUsersDTO>, IUserAwareService<AspNetUsersDTO>
    {
        private readonly IUOWFactory _uowfactory;

        public AspNetUsersService(IUOWFactory uowfactory)
        {
            _uowfactory = uowfactory;
        }

        public void Create(AspNetUsersDTO item)
        {
            ApplicationUser ApplicationUser;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<ApplicationUser>();

                ApplicationUser = AspNetUsersMapper.CreateAspNetUsers().Map(item);

                repo.Create(ApplicationUser);
            }
        }

        public void Delete(int id)
        {
            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<ApplicationUser>();
                repo.Delete(id);
                uow.BeginTransaction();
                uow.Commit();
            }
        }

        public AspNetUsersDTO Get(int id)
        {
            ApplicationUser ApplicationUser;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<ApplicationUser>();
                ApplicationUser = repo.Get(id);
            }
            AspNetUsersDTO dto = AspNetUsersMapper.CreateAspNetUsersDTO().Map(ApplicationUser);
            return dto;
        }

        public IEnumerable<AspNetUsersDTO> GetAll()
        {
            IEnumerable<ApplicationUser> categories;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<ApplicationUser>();

                categories = repo.GetAll();
            }
            IEnumerable<AspNetUsersDTO> dtos = AspNetUsersMapper.CreateListAspNetUsersDTO().Map(categories).ToList();

            return dtos;
        }

        public void Update(AspNetUsersDTO item)
        {
            ApplicationUser ApplicationUser = AspNetUsersMapper.CreateAspNetUsers().Map(item);

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<ApplicationUser>();
                repo.Update(ApplicationUser);
                uow.BeginTransaction();
                uow.Commit();
            }
        }
        public IEnumerable<AspNetUsersDTO> GetByUser(string id)
        {
            IEnumerable<ApplicationUser> ApplicationUsers;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<ApplicationUser>();
                ApplicationUsers = repo.GetAll().Where(e => e.Id == id);
            }
            IEnumerable<AspNetUsersDTO> dtos = AspNetUsersMapper.CreateListAspNetUsersDTO().Map(ApplicationUsers).ToList();
            return dtos;
        }
    }
}

