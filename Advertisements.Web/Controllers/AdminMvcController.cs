using System.Web.Mvc;
using Advertisements.Web.Filters;

namespace Advertisements.Web.Controllers
{
    [System.Web.Mvc.Authorize]
    [MyMvcCustomAuthFilter("Admin")]
    public class AdminMvcController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}