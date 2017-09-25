using System.Linq;
using Advertisements.DTO.Models;
using Advertisements.DataAccess.Repositories;
using Advertisements.DataAccess.Entities;
using Advertisements.BusinessLogic.Mapper;
using System.Collections.Generic;
using System;

namespace Advertisements.BusinessLogic.Services
{
    public class PasswordRecoveryService : IItemService<PasswordRecoveryDTO>
    {
        private readonly IUOWFactory _uowfactory;

        public PasswordRecoveryService(IUOWFactory uowfactory)
        {
            _uowfactory = uowfactory;
        }

        public void Create(PasswordRecoveryDTO item)
        {
            PasswordRecovery PasswordRecovery = PasswordRecoveryMapper.CreatePasswordRecovery().Map(item);

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<PasswordRecovery>();
                repo.Create(PasswordRecovery);
                uow.BeginTransaction();
                uow.Commit();
            }
        }

        public void Delete(int id)
        {
            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<PasswordRecovery>();
                repo.Delete(id);
                uow.BeginTransaction();
                uow.Commit();
            }
        }

        public PasswordRecoveryDTO Get(int id)
        {
            PasswordRecovery PasswordRecovery;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<PasswordRecovery>();
                PasswordRecovery = repo.Get(id);
            }
            PasswordRecoveryDTO dto = PasswordRecoveryMapper.CreatePasswordRecoveryDTO().Map(PasswordRecovery);
            return dto;
        }

        public IEnumerable<PasswordRecoveryDTO> GetAll()
        {
            IEnumerable<PasswordRecovery> categories;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<PasswordRecovery>();

                categories = repo.GetAll();
            }

            IEnumerable<PasswordRecoveryDTO> dtos = PasswordRecoveryMapper.CreateListAdvertisementDTO().Map(categories).ToList();

            return dtos;
        }

        public void Update(PasswordRecoveryDTO item)
        {
            PasswordRecovery PasswordRecovery = PasswordRecoveryMapper.CreatePasswordRecovery().Map(item);

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<PasswordRecovery>();
                repo.Update(PasswordRecovery);
                uow.BeginTransaction();
                uow.Commit();
            }
        }
        public bool IsValid(PasswordRecoveryDTO item)
        {
            throw new NotImplementedException();
        }
    }
}

