using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Advertisements.Web.Models;
using Advertisements.DataAccess.Entities;
<<<<<<< HEAD:Advertisements.Web/Providers/ApplicationOAuthProvider.cs
=======
using System.Threading;
using System.Drawing;
using Advertisements.Web.Csharp;
using System.IO;
using System.Web;
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d:Advertisements.Web/Providers/ApplicationOAuthProvider.cs
namespace Advertisements.Web.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;
        internal static string TokenName { get; } = "Token";
        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();
            CustomUserStore store = new CustomUserStore();
<<<<<<< HEAD:Advertisements.Web/Providers/ApplicationOAuthProvider.cs
            ApplicationUser user = store.FindByEmailAndPass(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
=======
            ApplicationUser user = await store.FindByEmailAndPass(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "305");
                
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d:Advertisements.Web/Providers/ApplicationOAuthProvider.cs
                return;
            }            

            ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager,
               OAuthDefaults.AuthenticationType);
            ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync(userManager,
                CookieAuthenticationDefaults.AuthenticationType);

            AuthenticationProperties properties = CreateProperties(user.UserName);
            AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
            context.Validated(ticket);
            context.Request.Context.Authentication.SignIn(cookiesIdentity);
<<<<<<< HEAD:Advertisements.Web/Providers/ApplicationOAuthProvider.cs
            context.Response.Cookies.Append(TokenName, context.Options.AccessTokenFormat.Protect(ticket));
=======

        }

        private void ValidateUserImg(ApplicationUser user)
        {
            Image image = Csharp.ImageConverter.ImgFromBytes(user.Avatar);
            if (image.Height > 64 || image.Width > 64)
            {
                image = Csharp.ImageConverter.SqueezeImg(image);
                user.Avatar = Csharp.ImageConverter.BytesFromImg(image);
            }
                
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d:Advertisements.Web/Providers/ApplicationOAuthProvider.cs
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }
    }
}