using System.Threading.Tasks;
using System.Web.Mvc;
using CSOMLocalDataProvider;
using Dashboard.Models;
using Dashboard.Util;

namespace Dashboard.Controllers
{
    /// <summary>
    /// Returning the programs availabe to the rest of widgets
    /// </summary>
    public class BaseDashboardController : Controller
    {
        private readonly CSOMContext _dbContext;

        public BaseDashboardController()
        {
            _dbContext = new CSOMContext();
        }

        [HttpGet]
        [Route("programs")]
        public async Task<ActionResult> Program()
        {
            var result = (new BaseProgramViewModel()).GetPrograms(_dbContext, null);
            var json = await JsonUtil.JsonResultAsync(result);
            return Content(json, "application/json");
        }

        [HttpGet]
        [Route("terms/{programId:int}")]
        public async Task<ActionResult> Term(int programId)
        {
            var result = new BaseTermVeiwModel().GetTerms(_dbContext, programId);

            var json = await JsonUtil.JsonResultAsync(result);
            return Content(json, "application/json");
        }

    }
}