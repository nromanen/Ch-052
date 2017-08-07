using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
