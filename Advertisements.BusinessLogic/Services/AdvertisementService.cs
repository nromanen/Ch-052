using System.Collections.Generic;
using System.Linq;
using Advertisements.BusinessLogic.Mapper;
using Advertisements.DataAccess.Entities;
using Advertisements.DataAccess.Repositories;
using Advertisements.DTO.Models;

namespace Advertisements.BusinessLogic.Services
{
    public class AdvertisementService : IAdvertisementService<AdvertisementDTO>
    {
        private readonly IUOWFactory _uowfactory;
        private const int TitleMinLenght = 3;

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
                advertisements = repo.Find(keyword, x => x.Resources);               
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
                Advertisement = repo.GetAll(o => o.Resources).Where(e => e.ApplicationUserId == id && e.IsDeleted != true);
            }
            IEnumerable<AdvertisementDTO> dtos = AdvertisementMapper.CreateListAdvertisementDTO().Map(Advertisement).ToList();
            return dtos;
        }

        public bool IsValid(AdvertisementDTO item)
        {
            if (item.Title == null || item.Description == null || item.TypeId <= 0 || item.CategoryId <= 0 ||
                item.Price < 0 || item.ApplicationUserId == null || item.Id != 0 )
            {
                return false;
            }

            else if(item.Title.Length < TitleMinLenght)
            {
                return false;
            }

            else
            {
                return true;
            }
        }
    }
}
