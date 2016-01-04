using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSOM.STS.DataAccess;

namespace Dashboard.Models.Queries
{
    public class TermQuery
    {
        private readonly CSOMContext _dbContext;

        public TermQuery(CSOMContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public IQueryable<TERM> GetProgramOpenTerms()
        //{
        //    _dbContext.
        //} 

    }
}