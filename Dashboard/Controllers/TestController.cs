using System.Threading.Tasks;
using System.Web.Mvc;
using CSOM.STS.DataAccess;
using Dashboard.Models;
using Newtonsoft.Json;

namespace Dashboard.Controllers
{
    public class TestController : Controller
    {
        protected readonly CSOMContext DbContext;

        // doing a simle query for a widget
        public TestController()
        {
            DbContext = new CSOMContext();
        }


        [HttpGet]
        [Route("test")]
        public ActionResult QueryTest()
        {
            var model = new TestClass();
            model = model.GetFromDb(DbContext);
            // return json
            var json = JsonConvert.SerializeObject(model);

            return Content(json, "application/json");
        }



    }
}