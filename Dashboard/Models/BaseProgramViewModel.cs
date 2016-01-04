using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSOM.STS.DataAccess;
using CSOM.STS.DataAccess.Repositories;
using Dashboard.Models.Queries;

namespace Dashboard.Models
{
    public class BaseProgramViewModel
    {
        List<TermModel> OpenTerms { get; set; } 
        public string Test = "this is a test";
        public IQueryable<int> Ids { get; set; } 

        public BaseProgramViewModel(CSOMContext dbContext)
        {
            OpenTerms = new List<TermModel>();

            //var pq = new ProgramsQuery(dbContext).GetPrograms().Select(p => p.PROGRAM_ID);
        }


    }
}