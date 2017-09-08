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
    public class AdvertisementService : IService<AdvertisementDTO>, IUserAwareService<AdvertisementDTO>, IAdvertisementAwareService<AdvertisementDTO>
    {
        private readonly IUOWFactory _uowfactory;

        public AdvertisementService(IUOWFactory uowfactory)
        {
            _uowfactory = uowfactory;
        }

        public IEnumerable<AdvertisementDTO> GetAll()
        {
            IEnumerable<Advertisement> advertisements;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Advertisement>();


                advertisements = repo.GetAll(x => x.Resources);
            }

            IEnumerable<AdvertisementDTO> dtos = AdvertisementMapper.CreateListAdvertisementDTO().Map(advertisements).ToList();

            return dtos;
        }

        public IEnumerable<AdvertisementDTO> Find(string keyword)
        {
            IEnumerable<Advertisement> advertisements;
            IEnumerable<AdvertisementDTO> dtos;
            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Advertisement>();


                advertisements = repo.Find(keyword, x => x.Resources/*, x => x.Type, x => x.Category*/);
                dtos = AdvertisementMapper.CreateListAdvertisementDTO().Map(advertisements).ToList();
            }

            return dtos;
        }

        public AdvertisementDTO Get(int id)
        {
            Advertisement advertisement;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Advertisement>();

                advertisement = repo.Get(id, o => o.Resources);
            }

            AdvertisementDTO dto = AdvertisementMapper.CreateAdvertisementDTO().Map(advertisement);

            return dto;
        }

        public void Create(AdvertisementDTO item)
        {
            Advertisement advertisement;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Advertisement>();

                advertisement = AdvertisementMapper.CreateAdvertisement().Map(item);

                repo.Create(advertisement);
                uow.BeginTransaction();
                uow.Commit();
            }
        }

        public void Update(AdvertisementDTO item)
        {
            Advertisement advertisement;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Advertisement>();

                advertisement = AdvertisementMapper.CreateAdvertisement().Map(item);

                repo.Update(advertisement);
                uow.BeginTransaction();
                uow.Commit();
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
        public IEnumerable<AdvertisementDTO> GetByUser(string id)
        {
            IEnumerable<Advertisement> Advertisement;

            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Advertisement>();
                Advertisement = repo.GetAll(o => o.Resources).Where(e => e.ApplicationUserId == id);
            }
            IEnumerable<AdvertisementDTO> dtos = AdvertisementMapper.CreateListAdvertisementDTO().Map(Advertisement).ToList();
            return dtos;
        }
    }
}
