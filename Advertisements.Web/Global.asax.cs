using Advertisements.BusinessLogic.Mapper;
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
            container.Register(typeof(IFeedbackAwareService<FeedbackDTO>), typeof(FeedbackService));
            container.Register(typeof(IUserService<AspNetUsersDTO>), typeof(AspNetUsersService));
            container.Register(typeof(IUserAwareService<AdvertisementDTO>), typeof(AdvertisementService));
            container.Register(typeof(IAdvertisementAwareService<AdvertisementDTO>), typeof(AdvertisementService));
            container.Register(typeof(IUserService<AdvertisementUsersDTO>), typeof(AdvertisementUsersService));

            container.Register(typeof(IService<Advertisement, AdvertisementDTO>), typeof(MyService<Advertisement, AdvertisementDTO>));
            container.Register(typeof(IService<Resource, ResourceDTO>), typeof(MyService<Resource, ResourceDTO>));
            container.Register(typeof(IService<ApplicationUser, AdvertisementUsersDTO>), typeof(MyService<ApplicationUser, AdvertisementUsersDTO>));
            container.Register(typeof(IService<Category, CategoryDTO>), typeof(MyService<Category, CategoryDTO>));
            container.Register(typeof(IService<AdvertisementType, TypeDTO>), typeof(MyService<AdvertisementType, TypeDTO>));
            container.Register(typeof(IService<Feedback, FeedbackDTO>), typeof(MyService<Feedback, FeedbackDTO>));
            container.Register(typeof(IService<ApplicationUser, AspNetUsersDTO>), typeof(MyService<ApplicationUser, AspNetUsersDTO>));

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        
    }
}
