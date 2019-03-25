using System.Web.Mvc;

namespace AlphaLeasing.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }        
    }
}