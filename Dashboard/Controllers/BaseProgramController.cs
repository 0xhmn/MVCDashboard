using System.Linq;
using System.Web.Mvc;
using CSOM.STS.DataAccess;
using Dashboard.Models;
using Dashboard.Models.Queries;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Dashboard.Controllers
{
    /// <summary>
    /// Returning the programs availabe to the rest of widgets
    /// </summary>
    public class BaseController : Controller
    {
        private readonly CSOMContext _dbContext;

        public BaseController()
        {
            _dbContext = new CSOMContext();
        }

        [HttpGet]
        [Route("programs")]
        public ActionResult Program()
        {
            var programs = new ProgramsQuery(_dbContext).GetPrograms();
            var result = programs.Select(p => new BaseProgramViewModel()
            {
                Id = p.PROGRAM_ID,
                Name = p.PROGRAM1
            });

            var json = JsonConvert.SerializeObject(result,
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

        [HttpGet]
        [Route("terms/{programId:int}")]
        public ActionResult Term(int programId)
        {
            var result = new TermQuery(_dbContext).GetProgramTerms(programId);

            var json = JsonConvert.SerializeObject(result,
            new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DefaultValueHandling = DefaultValueHandling.Include,
                DateParseHandling = DateParseHandling.DateTime,
                DateTimeZoneHandling = DateTimeZoneHandling.Unspecified,
                StringEscapeHandling = StringEscapeHandling.EscapeNonAscii,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Include
            });

            return Content(json, "application/json");
        }

    }
}