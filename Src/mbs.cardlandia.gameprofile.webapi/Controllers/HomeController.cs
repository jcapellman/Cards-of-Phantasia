using System.Web.Mvc;

namespace mbs.cardlandia.userprofile.webapi.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}