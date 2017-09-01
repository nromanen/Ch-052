using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertisements.BusinessLogic.Mapper;
using Advertisements.BusinessLogic.Services;
using Advertisements.DataAccess.Entities;
using Advertisements.DataAccess.Repositories;
using Advertisements.DTO.Models;

namespace Advertisements.BusinessLogic.Services
{
    public class AdvertisementTypeService : IService<AdvertisementTypeDTO>
    {
        private readonly IUOWFactory _uowfactory;

        public AdvertisementTypeService(IUOWFactory uowfactory)
        {
            _uowfactory = uowfactory;
        }

        public IEnumerable<AdvertisementTypeDTO> GetAll()
        {
            IEnumerable<AdvertisementType> AdvertisementTypes;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<AdvertisementType>();

                AdvertisementTypes = repo.GetAll();
            }

            IEnumerable<AdvertisementTypeDTO> dtos = AdvertisementTypeMapper.CreateListAdvertisementTypeDTO().Map(AdvertisementTypes).ToList();

            return dtos;
        }

        public AdvertisementTypeDTO Get(int id)
        {
            AdvertisementType AdvertisementType;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<AdvertisementType>();

                AdvertisementType = repo.Get(id);
            }

            AdvertisementTypeDTO dto = AdvertisementTypeMapper.CreateAdvertisementTypeDTO().Map(AdvertisementType);

            return dto;
        }

        public void Create(AdvertisementTypeDTO item)
        {
            AdvertisementType AdvertisementType;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<AdvertisementType>();

                AdvertisementType = AdvertisementTypeMapper.CreateAdvertisementType().Map(item);

                repo.Create(AdvertisementType);
                uow.BeginTransaction();
                uow.Commit();
            }
        }

        public void Update(AdvertisementTypeDTO item)
        {
            AdvertisementType AdvertisementType;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<AdvertisementType>();

                AdvertisementType = AdvertisementTypeMapper.CreateAdvertisementType().Map(item);

                repo.Update(AdvertisementType);
                uow.BeginTransaction();
                uow.Commit();
            }
        }

        public void Delete(int id)
        {
            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<AdvertisementType>();

                repo.Delete(id);
                uow.BeginTransaction();
                uow.Commit();
            }
        }
    }
}
