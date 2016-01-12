using System.Threading.Tasks;
using System.Web.Mvc;
using CSOM.STS.DataAccess;
using Dashboard.Models.WidgetModels;
using Dashboard.Util;

namespace Dashboard.Controllers.WidgetControllers
{
    public class TimeLineController : Controller
    {
        private readonly CSOMContext _dbContext;

        public TimeLineController()
        {
            _dbContext = new CSOMContext();
        }

        [HttpGet]
        [Route("timeline/{programId:int}")]
        public async Task<ActionResult> TimeLine(int programId)
        {
            var result = new TimeLineModel().GetTerms(_dbContext, programId);
            var json = await JsonUtil.JsonResultAsync(result);
            return Content(json, "application/json");
        }
    }
}