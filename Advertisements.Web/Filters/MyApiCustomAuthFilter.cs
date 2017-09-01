using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Advertisements.Web.Models;
using Advertisements.Web.Providers;
using Advertisements.Web.Results;
using System.Web.Mvc;
using System.Net.Mail;
using System.Text;
using Advertisements.DataAccess.Entities;
using Advertisements.DataAccess.Context;
using System.Threading;
using System.Linq;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Net;

namespace Advertisements.Web.Filters
{
    public class MyApiCustomAuthFilter : System.Web.Http.AuthorizeAttribute, System.Web.Http.Filters.IAuthorizationFilter
    {
        private ApplicationUserManager manager;
        private string[] roles;
        public bool AllowMultiple { get; }

        public MyApiCustomAuthFilter(params string[] Roles)
        {
            roles = Roles;
            manager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }
        
        public async Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            CustomUserStore store = new CustomUserStore();

<<<<<<< HEAD
=======
            //manager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
            var principal = actionContext.RequestContext.Principal;
            var user = await store.FindByIdAsync(principal.Identity.GetUserId());
            if (user == null)
            {
                base.HandleUnauthorizedRequest(actionContext);
            }
            bool inRoles = true;
            foreach (string role in roles)
            {
                if (!manager.IsInRole(user.Id, role))
                {
                    inRoles = false;
                    break;
                }
            }
            if (!inRoles)
            {
                return await Task.FromResult(actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized));
            }
            return await continuation();
        }
    }
}