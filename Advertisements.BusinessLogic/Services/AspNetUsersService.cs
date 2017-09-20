using System.Linq;
using Advertisements.DTO.Models;
using Advertisements.DataAccess.Repositories;
using Advertisements.DataAccess.Entities;
using Advertisements.BusinessLogic.Mapper;
using System.Collections.Generic;
using System;

namespace Advertisements.BusinessLogic.Services
{
    public class AspNetUsersService : IUserService<AspNetUsersDTO>
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
    }
}

