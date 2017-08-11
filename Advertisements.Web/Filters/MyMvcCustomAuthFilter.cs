using System.Web.Mvc;

namespace Advertisements.Web.Filters
{
    public class MyMvcCustomAuthFilter : System.Web.Mvc.AuthorizeAttribute, System.Web.Mvc.IAuthorizationFilter
    {
        private string[] roles;

        public MyMvcCustomAuthFilter(params string[] roles)
        {
            this.roles = roles;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {            
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                HandleUnauthorizedRequest(filterContext);
            }
            bool inRole = true;
            foreach (string role in this.roles) 
            {
                if (!filterContext.HttpContext.User.IsInRole(role))
                {
                    inRole = false;
                    break;
                }
            }

            if (!inRole)
            {
                HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}