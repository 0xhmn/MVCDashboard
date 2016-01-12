using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSOM.STS.DataAccess;
using Dashboard.Models.Intefaces;

namespace Dashboard.Models.WidgetModels
{
    public class TimeLineModel : ITermGetter<TimeLineModel>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public IQueryable<TimeLineModel> GetTerms(CSOMContext dbContext, int? programId)
        {
            var result = dbContext
                .TERMS_APPLY_ACTIVE
                .Where(t => t.PROGRAM_ID == programId)
                .Where(t => t.TERM.DATE_START != null)
                .Where(t => t.TERM.DATE_END != null)
                .Select(t => new TimeLineModel()
                {
                    Id = t.TERM_ID,
                    Name = t.TERM.TERM1,
                    StartDate = t.TERM.DATE_START.Value,
                    EndDate = t.TERM.DATE_END.Value
                });

            return result;
        }
    }
}