<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Cors;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Cors;
=======
﻿using System.Threading.Tasks; 
using Microsoft.Owin;    
using Owin;
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d

[assembly: OwinStartup(typeof(Advertisements.Web.Startup))]

namespace Advertisements.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
<<<<<<< HEAD
        {    
            var policy = new CorsPolicy()
            {
                AllowAnyHeader = true,
                AllowAnyMethod = true,
                SupportsCredentials = true,
                Origins = { "http://localhost:4200" }
            };
            policy.Origins.Add("domain");

            app.UseCors(new CorsOptions
            {
                PolicyProvider = new CorsPolicyProvider { PolicyResolver = context => Task.FromResult(policy) }
            });

            ConfigureAuth(app);

            //var config = new HttpConfiguration();
            //WebApiConfig.Register(config);
            //app.UseWebApi(config);
=======
        {
            ConfigureAuth(app);
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
        }  
    }
}
