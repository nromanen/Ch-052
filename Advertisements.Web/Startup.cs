﻿using System.Threading.Tasks;
using System.Web.Cors;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(Advertisements.Web.Startup))]

namespace Advertisements.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
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
        }  
    }
}
