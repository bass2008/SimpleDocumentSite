using System.Web.Mvc;

namespace AlphaLeasing.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public string Test()
        {
            return "hello";
        }
    }
}