using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Advertisements.DataAccess;
using Advertisements.DataAccess.Entities;
using Advertisements.DataAccess.Context;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Advertisements.Web.Models;
namespace Advertisements.Web.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
                   

            return View();
        }
        public ActionResult TakeConfirmEmail(string token,string eMail)
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
        //public ActionResult UserRegistration(User user)
        //{
        //    user.Active = true;
        //    user.RoleId = 1;
        //    using (AdvertisementsContext context = new AdvertisementsContext())
        //    {
        //        context.Users.Add(user);
        //        context.SaveChanges();
        //    }
        //    return View("Index");
        //}
    }
}
