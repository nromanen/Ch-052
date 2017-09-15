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
using Advertisements.Web.Filters;
using Advertisements.Web.App_LocalResources;
using System.Drawing;
using System.IO;

namespace Advertisements.Web.Controllers
{
    [System.Web.Http.RoutePrefix("api/Account")]
    public class AccountController : BaseApiController
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

        [System.Web.Http.Route("Roles")]
        public async Task<string[]> GetCurrentUserRoles()
        {
            var roles = await this.UserManager.GetRolesAsync(User.Identity.GetUserId());
            return roles.ToArray();
        }        

        private bool Send(string messageBody, string eMailAddr)
        {            
            var fromAddr = new MailAddress(EmailData.Email, EmailData.Header);
            var toAddr = new MailAddress(eMailAddr, "User");

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(EmailData.SmtpServer);
            mail.From = fromAddr;
            mail.To.Add(toAddr);
            mail.Subject = EmailData.Subject;
            mail.Body = messageBody;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("junglehunter2707@gmail.com", EmailData.Password);
            SmtpServer.EnableSsl = true;
            SmtpServer.Timeout = 5000;
            try
            {
                SmtpServer.Send(mail);
                return true;
            }
            catch(Exception exc)
            {
                return false;
            }
        }

        public static string FolderPath = AppDomain.CurrentDomain.BaseDirectory;

        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.Route("Register")]
        public async Task<IHttpActionResult> Register([FromBody]RegisterViewModel model)
        {
            Directory.CreateDirectory(FolderPath + @"\assets\images\" + model.Email);

            var user = new ApplicationUser() { UserName = model.UserName };
            user.Email = model.Email;

            string imgPath = HttpContext.Current.Server.MapPath("~/Content/Current_user_av.jpg");
            Image img = Image.FromFile(imgPath);
            img = Csharp.ImageConverter.SqueezeImg(img);
            user.Avatar = Csharp.ImageConverter.BytesFromImg(img);
            var result = await UserManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await UserManager.AddToRoleAsync(user.Id, "Customer");
            }
            else
            {
                string errors = "";
                foreach (string err in result.Errors)
                    errors += err + " ";
                return BadRequest("Occured some errors:" + errors);
            }

            string userEmailConfirmToken = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
            string currentUrl1 = HttpContext.Current.Request.Url.AbsoluteUri;
            string leftUrl = currentUrl1.Substring(0, currentUrl1.IndexOf("api"));

            string messageBody = string.Format("Hello, {0}! Please confirm your account by clicking this link:\n{1}",
                user.UserName, leftUrl + "confirmemail?token=" + userEmailConfirmToken + "&email=" + user.Email);
            if (!Send(messageBody, user.Email))
                ModelState.AddModelError("", "Could not send email message");

            if (!ModelState.IsValid)
            {
                await UserManager.DeleteAsync(user);
                string errMessages = "";
                foreach (var message in ModelState.Values)
                {
                     errMessages += message + " ";
                }
                return Ok(errMessages);
            }
            user.EmailToken = userEmailConfirmToken;
            await UserManager.UpdateAsync(user);

            

            return Ok("Check your email to end the registration");


        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("RestorePasswordRequest")]
        public async Task<IHttpActionResult> RestorePasswordRequest(RestorePasswordReqViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await UserManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest("This email doesn't exist");
            }

            string token = UserManager.GeneratePasswordResetToken(user.Id);
            string currentUrl1 = HttpContext.Current.Request.Url.AbsoluteUri;
            string leftUrl = currentUrl1.Substring(0, currentUrl1.IndexOf("api"));
            user.EmailToken = token;
            await UserManager.UpdateAsync(user);

            string messageBody = string.Format("Hello,{0} to restore your password go to this link:{1}/restorepassword?token={2}&email={3}",
                user.UserName, leftUrl, token, model.Email);
            Send(messageBody, model.Email);

            return Ok("Check your email to restore your password!");
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("ConfirmEmail")]
        public async Task<IHttpActionResult> ConfirmEmail(CheckPassRestoreDataViewModel model)
        {
            var user = await UserManager.FindByEmailAsync(model.Email);
            if (user == null || model.Token != user.EmailToken)
            {
                return BadRequest("Invalid url");
            }
            user.EmailConfirmed = true;
            user.EmailToken = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
            await UserManager.UpdateAsync(user);

            return Ok("You have successfully confirmed your email address");
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("CheckPassRestoreData")]
        public async Task<IHttpActionResult> CheckPassRestoreData(CheckPassRestoreDataViewModel model)
        {

            var user = await UserManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return Ok("Invalid url");
            }

            if (user.EmailToken != model.Token)
            {
                return Ok("Invalid url");
            }
            return Ok("Ok");
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("RestorePassword")]
        public async Task<IHttpActionResult> RestorePassword(RestorePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await UserManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return Ok("Error occured when password retore");
            }

            var result = await UserManager.ResetPasswordAsync(user.Id, user.EmailToken, model.NewPassword);
            user.EmailToken = "";
            await UserManager.UpdateAsync(user);
            if (result.Errors.ToArray().Length > 0)
            {
                string errors = "";
                foreach (string str in result.Errors)
                    errors += str + " ";
                return Ok(errors);
            }

            return Ok("Your password has successfully changed!");
        }
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("GetCustomerInfo")]
        public async Task<IHttpActionResult> GetCustomerInfo()
        { 
            CustomUserStore store = new CustomUserStore();
            string iD = User.Identity.GetUserId();
            ApplicationUser user = await store.FindByIdAsync(iD);

            return Ok(user);
        }

        [System.Web.Http.Authorize]
        [MyMvcCustomAuthFilter("Admin")]
        [System.Web.Http.Route("RegisterAdmin")]
        public async Task<IHttpActionResult> RegisterAdmin(RegisterViewModel model)
        {
            var user = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                EmailConfirmed = true,  
                
            };
            
            var adminResult = await UserManager.CreateAsync(user, model.Password);
            if (adminResult.Succeeded)
            {
                await UserManager.AddToRoleAsync(user.Id, "Admin");
                return Ok();
            }
            else
                return BadRequest("Не вдалося зареєструвати адміна");
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
        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

        // GET api/Account/UserInfo
        //[HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
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


       // [System.Web.Http.HttpGet]
        // POST api/Account/Logout
        [System.Web.Http.Route("Logout")]
        public IHttpActionResult Logout()
        {
            Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return Ok();
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

        [System.Web.Http.Route("getavatar/{id}")]
        [System.Web.Http.HttpGet]
        public async Task<string> GetUserAvatar(string id)
        {
            var user = await UserManager.FindByIdAsync(id);

            if (user == null)
            {
                return string.Empty;
            }
            return Convert.ToBase64String(user.Avatar);
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
        [System.Web.Http.Authorize(Roles ="Admin")]
        [System.Web.Http.Route("user/{id:guid}/roles")]
        [System.Web.Http.HttpPut]
        public async Task<IHttpActionResult> AssignRolesToUser([FromUri] string id, [FromBody] string[] rolesToAssign)
        {

            var appUser = await this.UserManager.FindByIdAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            var currentRoles = await this.UserManager.GetRolesAsync(appUser.Id);
            var rolesNotExist = rolesToAssign.Except(this.AppRoleManager.Roles.Select(x => x.Name)).ToArray();

            if (rolesNotExist.Count() > 0)
            {
                ModelState.AddModelError("", string.Format("Roles '{0}' does not exixts in the system", string.Join(",", rolesNotExist)));
                return BadRequest(ModelState);
            }

            IdentityResult removeResult = await this.UserManager.RemoveFromRolesAsync(appUser.Id, currentRoles.ToArray());

            if (!removeResult.Succeeded)
            {
                ModelState.AddModelError("", "Не вдалось видалити ролі юзера");
                return BadRequest(ModelState);
            }

            IdentityResult addResult = await this.UserManager.AddToRolesAsync(appUser.Id, rolesToAssign);

            if (!addResult.Succeeded)
            {
                ModelState.AddModelError("", "Не вдалось додати ролі юзерові");
                return BadRequest(ModelState);
            }
            return Ok();

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
