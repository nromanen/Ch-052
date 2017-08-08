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
using System.Web.Http.Cors;
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
    }
}
