using System.Threading.Tasks;
using System.Web.Mvc;
using CSOMLocalDataProvider;
using Dashboard.Models.WidgetModels;
using Dashboard.Util;

namespace Dashboard.Controllers.WidgetControllers
{
    public class CounterController : Controller
    {
        private readonly CSOMContext _dbContext;

        public CounterController()
        {
            _dbContext = new CSOMContext();
        }

        [Route("counterApplication/{programId}")]
        [HttpGet]
        public async Task<ActionResult> ProgramApplications(int programId)
        {
            var programs = new CounterModel().GetPrograms(_dbContext, programId);
            var json = await JsonUtil.JsonResultAsync(programs);
            return Content(json, "application/json");
        }
    }
}