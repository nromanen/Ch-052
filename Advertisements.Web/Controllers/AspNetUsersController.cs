using Advertisements.BusinessLogic.Services;
using Advertisements.DataAccess.Repositories;
using Advertisements.DataAccess.Services;
using Advertisements.DTO.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SimpleInjector;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Advertisements.Web.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/AspNetUsers")]
    public class AspNetUsersController : ApiController
    {
        IService<AspNetUsersDTO> service;
        
        public AspNetUsersController(IService<AspNetUsersDTO> s)
        {
            service = s;
        }

        [Authorize]
        [HttpGet]
        [Route("get/current")]
        public string GetCurrentuserId()
        {
            string UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            return UserId;
        }
    }
}