using System.Web.Mvc;
using Dashboard.Models;
using CSOM.STS.DataAccess;

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
            var model = new TestClass();
            model = model.GetFromDb(DbContext);
            return View();
        }
    }
}