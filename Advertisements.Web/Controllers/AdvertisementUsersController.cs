using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Advertisements.BusinessLogic.Services;
using Advertisements.DTO.Models;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
namespace Advertisements.Web.Controllers
{
    [RoutePrefix("api/AdvertisementUsers")]
    public class AdvertisementUsersController : ApiController
    {
        IUserService<AdvertisementUsersDTO> service;

        public AdvertisementUsersController(IUserService<AdvertisementUsersDTO> service)
        {
            this.service = service;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("get")]
        public IEnumerable<AdvertisementUsersDTO> GetAll()
        {
            return service.GetAll();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("get/{id}")]
        public AdvertisementUsersDTO Get(string id)
        {
            return service.Get(id);
        }
    }
}
