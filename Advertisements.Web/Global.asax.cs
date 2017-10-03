﻿using Advertisements.BusinessLogic.Mapper;
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

            container.Register(typeof(IMyService<Advertisement, AdvertisementDTO>), typeof(MyService<Advertisement, AdvertisementDTO>));
            container.Register(typeof(IMyService<Resource, ResourceDTO>), typeof(MyService<Resource, ResourceDTO>));
            container.Register(typeof(IMyService<ApplicationUser, AdvertisementUsersDTO>), typeof(MyService<ApplicationUser, AdvertisementUsersDTO>));
            container.Register(typeof(IMyService<Category, CategoryDTO>), typeof(MyService<Category, CategoryDTO>));
            container.Register(typeof(IMyService<AdvertisementType, TypeDTO>), typeof(MyService<AdvertisementType, TypeDTO>));
            container.Register(typeof(IMyService<Feedback, FeedbackDTO>), typeof(MyService<Feedback, FeedbackDTO>));
            container.Register(typeof(IMyService<ApplicationUser, AspNetUsersDTO>), typeof(MyService<ApplicationUser, AspNetUsersDTO>));

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        
    }
}
