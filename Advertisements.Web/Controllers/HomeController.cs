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
<<<<<<< HEAD
=======
using Advertisements.BusinessLogic.Services;
using Advertisements.DTO.Models;
using System.Drawing;
using System.IO;

>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
namespace Advertisements.Web.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
<<<<<<< HEAD
=======
        IUserService<AspNetUsersDTO> service;

        public HomeController(IUserService<AspNetUsersDTO> service)
        {
            this.service = service;
        }

>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

<<<<<<< HEAD
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
=======
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

        public ActionResult ConfirmPasswordRestoring(string token,string email)
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
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
        }

        public ActionResult Registrate()
        {
<<<<<<< HEAD
=======
            
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
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
<<<<<<< HEAD
=======

        public ActionResult GetImage()
        {
            string userId = User.Identity.GetUserId();
            var manager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser user = manager.FindById(userId);

            return File(user.Avatar, "image/jpg");
        }
        
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
    }
}
