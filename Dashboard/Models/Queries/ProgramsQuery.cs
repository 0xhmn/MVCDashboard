using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSOM.STS.DataAccess;

namespace Dashboard.Models.Queries
{
    public class ProgramsQuery
    {
        private readonly CSOMContext _dbContext;

        public ProgramsQuery(CSOMContext dbconContext)
        {
            _dbContext = dbconContext;
        }

        public IQueryable<PROGRAM> GetPrograms()
        {
            return _dbContext.PROGRAMS
                //.Include("TERMS_APPLY_ACTIVE")
                //.Include("TERMS_APPLY_ACTIVE.TERM")
                .Where(p => p.ONLINEAPP == true);
        }


    }
}