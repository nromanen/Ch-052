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
    public class AdvertisementService : IUserAwareService<AdvertisementDTO>, IAdvertisementAwareService<AdvertisementDTO>
    {
        private readonly IUOWFactory _uowfactory;
        private readonly BaseMapper _mapper;
        public AdvertisementService(IUOWFactory uowfactory)
        {
            _uowfactory = uowfactory;
            _mapper = new AdvertisementMapper();
        }     

        public IEnumerable<AdvertisementDTO> Find(string keyword)
        {
            IEnumerable<Advertisement> advertisements;
            IEnumerable<AdvertisementDTO> dtos;
            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Advertisement>();


                advertisements = repo.Find(keyword, x => x.Resources);
                dtos = this.UnboxAdvertisements(_mapper.MapCollection(advertisements));
            }
            return dtos;
        }        
        public IEnumerable<AdvertisementDTO> GetByUser(string id)
        {
            IEnumerable<Advertisement> advertisements;
            IEnumerable<AdvertisementDTO> dtos;
            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repo = uow.GetRepo<Advertisement>();
                advertisements = repo.GetAll(o => o.Resources).Where(e => e.ApplicationUserId == id);
            }
            dtos = this.UnboxAdvertisements(_mapper.MapCollection(advertisements)); 
            return dtos;
        }

        public IEnumerable<AdvertisementDTO> Get(int page, int pageSize)
        {
            IEnumerable<Advertisement> advertisements;
            IEnumerable<AdvertisementDTO> advertisementDTOs;
            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repository = uow.GetRepo<Advertisement>();
                advertisements = repository.GetAdvertisements(page, pageSize, (adv => adv.Resources));
                advertisementDTOs = this.UnboxAdvertisements(_mapper.MapCollection(advertisements));
            }
            return advertisementDTOs;
        }

        public int GetCount()
        {
            int count = 0;
            using (var uow = _uowfactory.CreateUnitOfWork())
            {
                var repository = uow.GetRepo<Advertisement>();
                count = repository.GetCount();
            }
            return count;
        }
        private IEnumerable<AdvertisementDTO> UnboxAdvertisements(IEnumerable<IDTO> dtos)
        {
            List<AdvertisementDTO> resultDTOS = new List<AdvertisementDTO>();
            foreach (var element in dtos)
            {
                resultDTOS.Add(element as AdvertisementDTO);
            }
            return resultDTOS;
        }
    }
}
