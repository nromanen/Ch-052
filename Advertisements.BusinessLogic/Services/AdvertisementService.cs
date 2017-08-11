using System.Linq;
using Advertisements.DTO.Models;
using Advertisements.DataAccess.Repositories;
using Advertisements.DataAccess.Entities;
using Advertisements.BusinessLogic.Mapper;
using System.Collections.Generic;

namespace Advertisements.BusinessLogic.Services
{
    public class AdvertisementService : IService<AdvertisementDTO>, IUserAwareService<AdvertisementDTO>
    {
        private readonly IUOWFactory _uowfactory;

        public AdvertisementService(IUOWFactory uowfactory)
        {
            _uowfactory = uowfactory;
        }

        public AdvertisementDTO Create(AdvertisementDTO item)
        {
            Advertisement Advertisement = AdvertisementMapper.CreateAdvertisement().Map(item);

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Advertisement>();
                repo.Create(Advertisement);
                uow.BeginTransaction();
                uow.Commit();
                return AdvertisementMapper.CreateAdvertisementDTO().Map(Advertisement);
            }
        }

        public void Delete(int id)
        {
            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Advertisement>();
                repo.Delete(id);
                uow.BeginTransaction();
                uow.Commit();
            }
        }

        public AdvertisementDTO Get(int id)
        {
            Advertisement Advertisement;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Advertisement>();
                Advertisement = repo.Get(id);
            }
            AdvertisementDTO dto = AdvertisementMapper.CreateAdvertisementDTO().Map(Advertisement);
            return dto;
        }

        public IEnumerable<AdvertisementDTO> GetAll()
        {
            IEnumerable<Advertisement> categories;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Advertisement>();

                categories = repo.GetAll();
            }
            IEnumerable<AdvertisementDTO> dtos = AdvertisementMapper.CreateListAdvertisementDTO().Map(categories).ToList();

            return dtos;
        }

        public void Update(AdvertisementDTO item)
        {
            Advertisement Advertisement = AdvertisementMapper.CreateAdvertisement().Map(item);

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Advertisement>();
                repo.Update(Advertisement);
                uow.BeginTransaction();
                uow.Commit();
            }
        }

        public IEnumerable<AdvertisementDTO> GetByUser(string id)
        {
            IEnumerable<Advertisement> Advertisement;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Advertisement>();
                Advertisement = repo.GetAll().Where(e => e.ApplicationUserId == id);
            }
            IEnumerable<AdvertisementDTO> dtos = AdvertisementMapper.CreateListAdvertisementDTO().Map(Advertisement).ToList();
            return dtos;
        }
    }
}

