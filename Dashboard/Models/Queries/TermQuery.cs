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

        public IQueryable<TermModel> GetProgramTerms(int programId)
        {
            var result = _dbContext
                .TERMS_APPLY_ACTIVE
                // .Include("TERM")
                .Where(t => t.PROGRAM_ID == programId)
                .Select(t => new TermModel()
                {
                    Id = t.TERM_ID,
                    Name = t.TERM.TERM1,
                    StartDate = t.TERM.DATE_START,
                    EndDate = t.TERM.DATE_END
                });
                // .Select(t => t.TERM_ID);
            return result;
        }


    }
}