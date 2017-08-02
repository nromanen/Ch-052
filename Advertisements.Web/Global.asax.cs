using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Advertisements.DataAccess.Entities;
using Advertisements.DataAccess.Context;
namespace Advertisements.Web
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

            //Role userRole = new Role();
            //userRole.Id = 1;
            //userRole.Name = "userRole";
            //using (AdvertisementsContext context = new AdvertisementsContext())
            //{
            //    context.Roles.Add(userRole);
            //    context.SaveChanges();
            //}
        }
    }
}
