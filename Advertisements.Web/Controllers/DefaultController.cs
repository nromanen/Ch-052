using System.Web.Mvc;

namespace Advertisements.Web.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            ViewBag.data = new CategoryController().Get(2);
            return View();
        }
    }
}