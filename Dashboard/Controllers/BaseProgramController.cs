using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CSOM.STS.DataAccess;
using CSOM.STS.DataAccess.Repositories;
using Dashboard.Models;
using Dashboard.Models.Queries;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Dashboard.Controllers
{
    /// <summary>
    /// Returning the temrs availabe to the rest of widgets
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
            var pq = new ProgramsQuery(_dbContext).GetPrograms().Select(p => p.PROGRAM_ID);

            var json = JsonConvert.SerializeObject(pq,
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