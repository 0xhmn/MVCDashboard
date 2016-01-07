using System.Linq;
using System.Web.Mvc;
using CSOM.STS.DataAccess;
using Dashboard.Models.Queries;
using Dashboard.Models.WidgetModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Dashboard.Controllers
{
    public class CounterController : Controller
    {
        private readonly CSOMContext _dbContext;

        public CounterController()
        {
            _dbContext = new CSOMContext();
        }

        // count all the applications for all the programs
        [Route("counterApplication/{programId}")]
        [HttpGet]
        public ActionResult ProgramApplications(int programId)
        {
            var programs = new ProgramsQuery(_dbContext).GetPrograms()
                .Select(p => new CounterWidgetModel()
                {
                    Id = p.PROGRAM_ID,
                    Name = p.PROGRAM1,
                    NumberOfApplications = p.APPLICATIONS.Count(),
                    IsSelected = (p.PROGRAM_ID == programId)
                });

            var json = JsonConvert.SerializeObject(programs,
            new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DefaultValueHandling = DefaultValueHandling.Include,
                StringEscapeHandling = StringEscapeHandling.EscapeNonAscii,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Include
            });

            return Content(json, "application/json");
        }
    }
}