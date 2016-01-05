using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSOM.STS.DataAccess;

namespace Dashboard.Models.Queries
{
    /// <summary>
    /// selecting all the terms for each program
    /// </summary>
    public class TermQuery
    {
        private readonly CSOMContext _dbContext;

        public TermQuery(CSOMContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TERM> GetProgramTerms(PROGRAM p)
        {
            return p.TERMS_APPLY_ACTIVE
                .Select(t => t.TERM)
                .OrderBy(t => t.TERM_ID)
                .AsQueryable();
        }

    }
}