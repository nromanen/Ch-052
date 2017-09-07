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
using System.Threading.Tasks;
namespace Advertisements.Web.Controllers
{

    [RoutePrefix("api/Advertisement")]
    public class AdvertisementController : ApiController
    {


        IService<AdvertisementDTO> service;
        IUserAwareService<AdvertisementDTO> userService;
        IAdvertisementAwareService<AdvertisementDTO> advertService;

        public AdvertisementController(IService<AdvertisementDTO> s, IUserAwareService<AdvertisementDTO> us, IAdvertisementAwareService<AdvertisementDTO> advs)
        {
            service = s;
            userService = us;
            advertService = advs;
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

        [AllowAnonymous]
        [HttpGet]
        [Route("find/{keyword}")]
        public  IEnumerable<AdvertisementDTO> Find(string keyword)
        {
            return advertService.Find(keyword);
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
