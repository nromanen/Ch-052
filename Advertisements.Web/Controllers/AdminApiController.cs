using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
namespace Advertisements.Web.Controllers
{
    public class AdminApiController : BaseApiController
    {
        [Authorize(Roles = "Admin")]
        [Route("users")]
        public IHttpActionResult GetUsers()
        {
            throw new NotImplementedException();
        }

        [Authorize(Roles = "Admin")]
        [Route("user/{id:guid}", Name = "GetUserById")]
        public  Task<IHttpActionResult> GetUser(string Id)
        {
            throw new NotImplementedException();
        }


        [Authorize(Roles = "Admin")]
        [Route("user/{username}")]
        public  Task<IHttpActionResult> GetUserByName(string username)
        {
            throw new NotImplementedException();
        }

        [Authorize(Roles = "Admin")]
        [Route("user/{id:guid}")]
        public  Task<IHttpActionResult> DeleteUser(string id)
        {
            throw new NotImplementedException();
        }
    }
}
