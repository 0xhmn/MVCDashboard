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

        // only programs that have a term
        public IQueryable<PROGRAM> GetPrograms()
        {
            return _dbContext.PROGRAMS
                .Where(p => p.TERMS_APPLY_ACTIVE.Any())
                .OrderBy(p => p.SORT_ORDER);
        }

        public IQueryable<PROGRAM> GetProgramById(int programId)
        {
            return _dbContext.PROGRAMS
                .Where(p => p.PROGRAM_ID == programId);
        } 

    }
}