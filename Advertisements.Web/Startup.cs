using System.Threading.Tasks; 
using Microsoft.Owin;    
using Owin;

[assembly: OwinStartup(typeof(Advertisements.Web.Startup))]

namespace Advertisements.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }  
    }
}
