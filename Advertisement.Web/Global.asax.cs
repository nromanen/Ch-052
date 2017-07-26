using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Advertisement.DataAccess;

namespace Advertisement.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //if you want to test database creating by code first please use this code:

            //AdvertisementDbContext db = new AdvertisementDbContext();
            //db.Roles.Add(new DataAccess.Entities.Role { Name = "admin" });
            //db.SaveChanges();
        }
    }
}
