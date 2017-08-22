using Advertisements.BusinessLogic.Services;
using Advertisements.DataAccess.Entities;
using Advertisements.DataAccess.Repositories;
using Advertisements.DataAccess.Services;
using Advertisements.DTO.Models;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;       
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


            Container container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<IUOWFactory, UOWFactory>(Lifestyle.Singleton);
            container.Register(typeof(IService<CategoryDTO>), typeof(CategoryService));
            container.Register(typeof(IService<FeedbackDTO>), typeof(FeedbackService));
            //container.Register(typeof(IService<AspNetUsersDTO>), typeof(AspNetUsersService));
            container.Register(typeof(IUserService<AspNetUsersDTO>), typeof(AspNetUsersService));
            container.Register(typeof(IService<AdvertisementDTO>), typeof(AdvertisementService));
            container.Register(typeof(IUserAwareService<AdvertisementDTO>), typeof(AdvertisementService));

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        
    }
}
