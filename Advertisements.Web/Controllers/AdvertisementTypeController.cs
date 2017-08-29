using Advertisements.BusinessLogic.Services;
using Advertisements.DataAccess.Repositories;
using Advertisements.DataAccess.Services;
using Advertisements.DTO.Models;
using SimpleInjector;
using System.Collections.Generic;
using System.Web.Http;

namespace Advertisements.Web.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/AdvertisementType")]
    public class AdvertisementTypeController : ApiController
    {

        IService<AdvertisementTypeDTO> service;

        public AdvertisementTypeController(IService<AdvertisementTypeDTO> s)
        {
            service = s;
        }

        [HttpGet]
        [Route("get")]
        public IEnumerable<AdvertisementTypeDTO> Get()
        {
            return service.GetAll();
        }


        [HttpGet]
        [Route("get/{id}")]
        public AdvertisementTypeDTO Get(int id)
        {
            return service.Get(id);
        }

        [HttpPost]
        [Route("add")]
        public void Add(AdvertisementTypeDTO dto)
        {
            service.Create(dto);
        }

        [HttpPut]
        [Route("edit")]
        public void Update(AdvertisementTypeDTO dto)
        {
            service.Update(dto);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
