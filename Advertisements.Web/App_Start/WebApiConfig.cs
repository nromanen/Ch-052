using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
<<<<<<< HEAD:Advertisements.Web/App_Start/WebApiConfig.cs
using System.Web.Http;
using System.Web.Http.Cors;
=======
using System.Web.Http; 
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d:Advertisements.Web/App_Start/WebApiConfig.cs
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace Advertisements.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        { 
<<<<<<< HEAD:Advertisements.Web/App_Start/WebApiConfig.cs
            // Web API configuration and services
            // Configure Web APIv to use only bearer token authentication.
=======
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d:Advertisements.Web/App_Start/WebApiConfig.cs
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            
<<<<<<< HEAD:Advertisements.Web/App_Start/WebApiConfig.cs
            //config.EnableCors();
            // Web API routes
=======
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d:Advertisements.Web/App_Start/WebApiConfig.cs
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
          
        }
    }
}
