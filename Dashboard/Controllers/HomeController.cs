using System.Web.Mvc;
using CSOMLocalDataProvider;
using Dashboard.Models;

namespace Dashboard.Controllers
{
    public class HomeController : Controller
    {
        protected readonly CSOMContext DbContext;

        public HomeController()
        {
            DbContext = new CSOMContext();
        }

        [Route("")]
        public ActionResult Index()
        {
            return View();
        }
    }
}