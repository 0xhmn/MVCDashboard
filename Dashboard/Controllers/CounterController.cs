using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSOM.STS.DataAccess;
using Dashboard.Models;
using Dashboard.Models.Queries;
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

        // count all the applications available for a certain program
        [Route("counterApplication/{programId}")] //Route: /Users/12
        [HttpGet]
        public ActionResult ProgramApplications(int programId)
        {
            //var result = new ProgramsQuery(_dbContext)
            //    .GetProgramById(programId)
            //    .Select(p => new { count = p.APPLICATIONS.Count()});
            //var json = JsonConvert.SerializeObject(result,
            //new JsonSerializerSettings());

            var programs = new ProgramsQuery(_dbContext).GetPrograms()
                // .Select(p => p.APPLICATIONS.Count());
                .Select(p => new ProgramCountModel()
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