using System.Net.Http;
using System.Web.Http;
using Advertisements.Web.Models;
using Microsoft.AspNet.Identity.Owin;

namespace Advertisements.Web.Controllers
{
    public class BaseApiController : ApiController
    {
        private ApplicationRoleManager _appRoleManager = null;

        protected ApplicationRoleManager AppRoleManager
        {
            get { return this._appRoleManager ?? Request.GetOwinContext().GetUserManager<ApplicationRoleManager>(); }
        }
    }
}
