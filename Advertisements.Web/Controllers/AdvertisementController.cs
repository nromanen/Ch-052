using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Advertisements.BusinessLogic.Services;
using Advertisements.DTO.Models;

namespace Advertisements.Web.Controllers
{

    [Authorize]
    [RoutePrefix("api/Advertisement")]
    public class AdvertisementController : ApiController
    {


        IService<AdvertisementDTO> service;

        public AdvertisementController(IService<AdvertisementDTO> s)
        {
            service = s;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("get")]
        public IEnumerable<AdvertisementDTO> Get()
        {
            return service.GetAll();
        }


        [HttpGet]
        [Route("get/{id}")]
        public AdvertisementDTO Get(int id)
        {
            return service.Get(id);
        }

        [HttpPost]
        [Route("add")]
        public void Add(AdvertisementDTO dto)
        {
            service.Create(dto);
        }

        [HttpPut]
        [Route("edit")]
        public void Update(AdvertisementDTO dto)
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
