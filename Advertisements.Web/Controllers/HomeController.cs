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
namespace Advertisements.Web.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            if (HttpContext.User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "AdminMvc");
            }

            return View();
        }
        public ActionResult TakeConfirmEmail(string token, string eMail)
        {
            ViewBag.token = token;
            ViewBag.eMail = eMail;
            return View();
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
    }
}
