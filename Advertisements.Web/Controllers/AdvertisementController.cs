using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Advertisements.BusinessLogic.Services;
using Advertisements.DTO.Models;
using System.Threading;
using Microsoft.AspNet.Identity;

namespace Advertisements.Web.Controllers
{

    [RoutePrefix("api/Advertisement")]
    public class AdvertisementController : ApiController
    {


        IService<AdvertisementDTO> service;
        IUserAwareService<AdvertisementDTO> userService;

        public AdvertisementController(IService<AdvertisementDTO> s, IUserAwareService<AdvertisementDTO> us)
        {
            service = s;
            userService = us;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("get")]
        public IEnumerable<AdvertisementDTO> Get()
        {
            return service.GetAll();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("get/{id}")]
        public AdvertisementDTO Get(int id)
        {
            return service.Get(id);
        }

        [Authorize]
        [HttpPost]
        [Route("add")]
        public void Add(AdvertisementDTO dto)
        {
            service.Create(dto);
        }

        [Authorize]
        [HttpPut]
        [Route("edit")]
        public void Update(AdvertisementDTO dto)
        {
            service.Update(dto);
        }

        [Authorize]
        [HttpDelete]
        [Route("delete/{id}")]
        public void Delete(int id)
        {
            service.Delete(id);
        }

        [Authorize]
        [HttpGet]
        [Route("get/current")]
        public IEnumerable<AdvertisementDTO> GetCurrentUsersAdv()
        {
            string userId = Thread.CurrentPrincipal.Identity.GetUserId();
            return userService.GetByUser(userId);
        }
    }
}
