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

namespace Advertisements.Web.Controllers
{
    [System.Web.Http.Authorize]
    [System.Web.Http.RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private const string LocalLoginProvider = "Local";
        private ApplicationUserManager _userManager;

        public AccountController() { }     

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private void Send(string messageBody, string eMailAddr)
        {
            const string pass = "07cd1997";
            var fromAddr = new MailAddress("junglehunter2707@gmail.com", "Our service");
            var toAddr = new MailAddress(eMailAddr, "User");

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = fromAddr;
            mail.To.Add(toAddr);
            mail.Subject = "Test Mail";
            mail.Body = messageBody;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("junglehunter2707@gmail.com", pass);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }

        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.Route("Register")]
        public async Task<IHttpActionResult> Register([FromBody]RegisterViewModel model)
        {

            var user = new ApplicationUser() { UserName = model.UserName };
            user.Email = model.Email;
            user.EmailConfirmed = true;
            var result = await UserManager.CreateAsync(user, model.Password);


            string token = Encrypt(model.Email + DateTime.Now, true);
            string messageBody = string.Format("Для завершення реєстрації перейдіть по посиланню:" +
                        "<a href=\"{0}\" title = \"Підтвердити реєстрацію\">{0}</a>",
                        "https://localhost:44335/Home/TakeConfirmEmail?token=" + token + "&eMail=" + model.Email);
            Send(messageBody, user.Email);
            return Ok();

        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        [ValidateAntiForgeryToken]
        [System.Web.Http.Route("Login")]
        public async Task<IHttpActionResult> Login([FromBody]RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = UserManager.FindByEmail(model.Email);

            var authContext = HttpContext.Current.GetOwinContext().Authentication;
            UserManager<IdentityUser> _manager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new ApplicationDbContext()));
            var userFind = _manager.Find(model.Email, model.Password);
            if (user != null)
            {
                if (!await UserManager.IsEmailConfirmedAsync(user.Id))
                {
                    string message = "Треба підтвердити електронну пошту";
                    return BadRequest(message);
                }
            }
            var signInManager = new SignInManager<ApplicationUser, string>(UserManager, HttpContext.Current.GetOwinContext().Authentication);
            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, true, false);

            switch (result)
            {
                case SignInStatus.Success:
                    return Ok();
                case SignInStatus.RequiresVerification:
                    ModelState.AddModelError("Потрібна верифікація", new Exception());
                    return BadRequest(ModelState);

                default:
                    ModelState.AddModelError("Не вдалося ввійтив систему", new Exception());
                    return BadRequest(ModelState);
            }

        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.Route("ConfirmEmail")]
        public async Task<ActionResult> ConfirmEmail(string token, string eMail)
        {
            string userId = token;
            ApplicationUser user = this.UserManager.FindById(userId);
            if (user != null)
            {
                if (user.Email == eMail)
                {
                    user.EmailConfirmed = true;
                    await UserManager.UpdateAsync(user);
                    await HttpContext.Current.GetOwinContext()
                        .Get<SignInManager<ApplicationUser, string>>().SignInAsync(user, isPersistent: false, rememberBrowser: false);

                }
            }
            return null;
        }

        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

        // GET api/Account/UserInfo
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [System.Web.Http.Route("UserInfo")]
        public UserInfoViewModel GetUserInfo()
        {
            ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

            return new UserInfoViewModel
            {
                Email = User.Identity.GetUserName(),
                HasRegistered = externalLogin == null,
                LoginProvider = externalLogin != null ? externalLogin.LoginProvider : null
            };
        }


        [System.Web.Http.HttpGet]
        // POST api/Account/Logout
        [System.Web.Http.Route("Logout")]
        public IHttpActionResult Logout()
        {
            var autheticationManager = HttpContext.Current.GetOwinContext().Authentication;
            this.Authentication.SignOut(this.Authentication.User.Identity.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType);


            HttpCookie currentUserCookie = HttpContext.Current.Request.Cookies[".AspNet.Cookies"];
            HttpContext.Current.Response.Cookies.Remove(".AspNet.Cookies");
            currentUserCookie.Expires = DateTime.Now.AddDays(-30);
            currentUserCookie.Value = null;
            HttpContext.Current.Response.SetCookie(currentUserCookie);
            currentUserCookie = HttpContext.Current.Request.Cookies["Token"];
            HttpContext.Current.Response.Cookies.Remove("Token");
            currentUserCookie.Expires = DateTime.Now.AddDays(-30);
            currentUserCookie.Value = null;
            HttpContext.Current.Response.SetCookie(currentUserCookie);

            bool flag = HttpContext.Current.Request.IsAuthenticated;
            return this.Ok(new { message = "Logout successful." });
        }



        // GET api/Account/ManageInfo?returnUrl=%2F&generateState=true
        [System.Web.Http.Route("ManageInfo")]
        public async Task<ManageInfoViewModel> GetManageInfo(string returnUrl, bool generateState = false)
        {
            IdentityUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            if (user == null)
            {
                return null;
            }

            List<UserLoginInfoViewModel> logins = new List<UserLoginInfoViewModel>();

            foreach (IdentityUserLogin linkedAccount in user.Logins)
            {
                logins.Add(new UserLoginInfoViewModel
                {
                    LoginProvider = linkedAccount.LoginProvider,
                    ProviderKey = linkedAccount.ProviderKey
                });
            }

            if (user.PasswordHash != null)
            {
                logins.Add(new UserLoginInfoViewModel
                {
                    LoginProvider = LocalLoginProvider,
                    ProviderKey = user.UserName,
                });
            }

            return new ManageInfoViewModel
            {
                LocalLoginProvider = LocalLoginProvider,
                Email = user.UserName,
                Logins = logins,
                ExternalLoginProviders = GetExternalLogins(returnUrl, generateState)
            };
        }

        // POST api/Account/ChangePassword
        [System.Web.Http.Route("ChangePassword")]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword,
                model.NewPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        // POST api/Account/SetPassword
        [System.Web.Http.Route("SetPassword")]
        public async Task<IHttpActionResult> SetPassword(SetPasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        // POST api/Account/AddExternalLogin
        [System.Web.Http.Route("AddExternalLogin")]
        public async Task<IHttpActionResult> AddExternalLogin(AddExternalLoginBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);

            AuthenticationTicket ticket = AccessTokenFormat.Unprotect(model.ExternalAccessToken);

            if (ticket == null || ticket.Identity == null || (ticket.Properties != null
                && ticket.Properties.ExpiresUtc.HasValue
                && ticket.Properties.ExpiresUtc.Value < DateTimeOffset.UtcNow))
            {
                return BadRequest("External login failure.");
            }

            ExternalLoginData externalData = ExternalLoginData.FromIdentity(ticket.Identity);

            if (externalData == null)
            {
                return BadRequest("The external login is already associated with an account.");
            }

            IdentityResult result = await UserManager.AddLoginAsync(User.Identity.GetUserId(),
                new UserLoginInfo(externalData.LoginProvider, externalData.ProviderKey));

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        // POST api/Account/RemoveLogin
        [System.Web.Http.Route("RemoveLogin")]
        public async Task<IHttpActionResult> RemoveLogin(RemoveLoginBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result;

            if (model.LoginProvider == LocalLoginProvider)
            {
                result = await UserManager.RemovePasswordAsync(User.Identity.GetUserId());
            }
            else
            {
                result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(),
                    new UserLoginInfo(model.LoginProvider, model.ProviderKey));
            }

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        // GET api/Account/ExternalLogin
        [System.Web.Http.OverrideAuthentication]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalCookie)]
        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.Route("ExternalLogin", Name = "ExternalLogin")]
        public async Task<IHttpActionResult> GetExternalLogin(string provider, string error = null)
        {
            if (error != null)
            {
                return Redirect(Url.Content("~/") + "#error=" + Uri.EscapeDataString(error));
            }

            if (!User.Identity.IsAuthenticated)
            {
                return new ChallengeResult(provider, this);
            }

            ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

            if (externalLogin == null)
            {
                return InternalServerError();
            }

            if (externalLogin.LoginProvider != provider)
            {
                Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                return new ChallengeResult(provider, this);
            }

            ApplicationUser user = await UserManager.FindAsync(new UserLoginInfo(externalLogin.LoginProvider,
                externalLogin.ProviderKey));

            bool hasRegistered = user != null;

            if (hasRegistered)
            {
                Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);

                ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(UserManager,
                   OAuthDefaults.AuthenticationType);
                ClaimsIdentity cookieIdentity = await user.GenerateUserIdentityAsync(UserManager,
                    CookieAuthenticationDefaults.AuthenticationType);

                AuthenticationProperties properties = ApplicationOAuthProvider.CreateProperties(user.UserName);
                Authentication.SignIn(properties, oAuthIdentity, cookieIdentity);
            }
            else
            {
                IEnumerable<Claim> claims = externalLogin.GetClaims();
                ClaimsIdentity identity = new ClaimsIdentity(claims, OAuthDefaults.AuthenticationType);
                Authentication.SignIn(identity);
            }

            return Ok();
        }

        // GET api/Account/ExternalLogins?returnUrl=%2F&generateState=true
        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.Route("ExternalLogins")]
        public IEnumerable<ExternalLoginViewModel> GetExternalLogins(string returnUrl, bool generateState = false)
        {
            IEnumerable<AuthenticationDescription> descriptions = Authentication.GetExternalAuthenticationTypes();
            List<ExternalLoginViewModel> logins = new List<ExternalLoginViewModel>();

            string state;

            if (generateState)
            {
                const int strengthInBits = 256;
                state = RandomOAuthStateGenerator.Generate(strengthInBits);
            }
            else
            {
                state = null;
            }

            foreach (AuthenticationDescription description in descriptions)
            {
                ExternalLoginViewModel login = new ExternalLoginViewModel
                {
                    Name = description.Caption,
                    Url = Url.Route("ExternalLogin", new
                    {
                        provider = description.AuthenticationType,
                        response_type = "token",
                        client_id = Startup.PublicClientId,
                        redirect_uri = new Uri(Request.RequestUri, returnUrl).AbsoluteUri,
                        state = state
                    }),
                    State = state
                };
                logins.Add(login);
            }

            return logins;
        }

        // POST api/Account/Register
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.Route("RegisterBindModel")]
        public async Task<IHttpActionResult> Register(RegisterBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };

            IdentityResult result = await UserManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        // POST api/Account/RegisterExternal
        [System.Web.Http.OverrideAuthentication]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [System.Web.Http.Route("RegisterExternal")]
        public async Task<IHttpActionResult> RegisterExternal(RegisterExternalBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var info = await Authentication.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return InternalServerError();
            }

            var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };
            user.EmailConfirmed = true;
            IdentityResult result = await UserManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            result = await UserManager.AddLoginAsync(user.Id, info.Login);
            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }
        private string Encrypt(string strToEnc, bool useHash)
        {
            byte[] keyArr;
            byte[] toEncryptBytes = Encoding.UTF8.GetBytes(strToEnc);

            System.Configuration.AppSettingsReader settingsReader = new System.Configuration.AppSettingsReader();

            string key = "myKey";

            if (useHash)
            {
                MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
                keyArr = md5Provider.ComputeHash(Encoding.UTF8.GetBytes(key));
                md5Provider.Clear();
            }
            else
                keyArr = Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider cryptoProvider = new TripleDESCryptoServiceProvider();
            cryptoProvider.Key = keyArr;
            cryptoProvider.Mode = CipherMode.ECB;
            cryptoProvider.Padding = PaddingMode.PKCS7;

            ICryptoTransform cryptoTransform = cryptoProvider.CreateEncryptor();

            byte[] resultBytes =
                cryptoTransform.TransformFinalBlock(toEncryptBytes, 0, toEncryptBytes.Length);
            cryptoProvider.Clear();

            return Convert.ToBase64String(resultBytes, 0, resultBytes.Length);
        }

        #region Helpers

        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

        private class ExternalLoginData
        {
            public string LoginProvider { get; set; }
            public string ProviderKey { get; set; }
            public string UserName { get; set; }

            public IList<Claim> GetClaims()
            {
                IList<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, ProviderKey, null, LoginProvider));

                if (UserName != null)
                {
                    claims.Add(new Claim(ClaimTypes.Name, UserName, null, LoginProvider));
                }

                return claims;
            }

            public static ExternalLoginData FromIdentity(ClaimsIdentity identity)
            {
                if (identity == null)
                {
                    return null;
                }

                Claim providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);

                if (providerKeyClaim == null || String.IsNullOrEmpty(providerKeyClaim.Issuer)
                    || String.IsNullOrEmpty(providerKeyClaim.Value))
                {
                    return null;
                }

                if (providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
                {
                    return null;
                }

                return new ExternalLoginData
                {
                    LoginProvider = providerKeyClaim.Issuer,
                    ProviderKey = providerKeyClaim.Value,
                    UserName = identity.FindFirstValue(ClaimTypes.Name)
                };
            }
        }

        private static class RandomOAuthStateGenerator
        {
            private static RandomNumberGenerator _random = new RNGCryptoServiceProvider();

            public static string Generate(int strengthInBits)
            {
                const int bitsPerByte = 8;

                if (strengthInBits % bitsPerByte != 0)
                {
                    throw new ArgumentException("strengthInBits must be evenly divisible by 8.", "strengthInBits");
                }

                int strengthInBytes = strengthInBits / bitsPerByte;

                byte[] data = new byte[strengthInBytes];
                _random.GetBytes(data);
                return HttpServerUtility.UrlTokenEncode(data);
            }
        }

        #endregion
    }
}
