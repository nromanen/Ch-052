using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Advertisements.Web.Models;
using System.Web.Mvc;
using Advertisements.DataAccess.Entities;
using Advertisements.DataAccess.Context;
using System.Linq;
using Advertisements.BusinessLogic.Services;
using Advertisements.DTO.Models;

namespace Advertisements.Web.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        IUserService<AspNetUsersDTO> service;

        public HomeController(IUserService<AspNetUsersDTO> service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public async Task<ActionResult> TakeConfirmEmail(string token, string Id)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var result = await userManager.CustomCheckEmailTokenAsync(Id, token);
            if (!result.Succeeded && result.Errors.ToArray().Length != 0)
            {
                string error = "";
                foreach (string msg in result.Errors)
                    error += msg + " ";
                return View(error);
            }
            string message = "You have succesfully confirmed your email";
            return View((object)message);
        }

        public ActionResult RestorePassword()
        {
            return View();
        }

        public ActionResult ConfirmPasswordRestoring(string token, string email)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.FindByEmail(email);

            if (user == null)
            {
                ViewBag.message = "Invalid url for password restoring";
                return View((object)"0");
            }
            string tokenToCheck = user.EmailToken.Replace('+', ' ');
            if (token != tokenToCheck)
            {
                ViewBag.message = "Invalid token!";
                return View((object)"0");
            }
            return View((object)user.Id);
        }

        public ActionResult Registrate()
        {

            RegisterViewModel u = new RegisterViewModel();
            return View(u);
        }
        public ActionResult Login()
        {
            return View();
        }
        private void AddToRoles()
        {
            var manager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                foreach (ApplicationUser user in context.Users)
                {
                    if (user.UserName == "d_maryshchuk")
                    {
                        manager.AddToRole(user.Id, "Admin");
                        continue;
                    }
                    if (!manager.IsInRole(user.Id, "Customer"))
                    {
                        manager.AddToRole(user.Id, "Customer");
                    }
                }
            }
        }

        public ActionResult GetImage()
        {
            string userId = User.Identity.GetUserId();
            var manager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser user = manager.FindById(userId);


            return File(user.Avatar, "image/jpg");
        }

    }
}
