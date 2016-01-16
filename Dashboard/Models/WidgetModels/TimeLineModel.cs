using System;
using System.Linq;
using CSOMLocalDataProvider;
using Dashboard.Models.Intefaces;

namespace Dashboard.Models.WidgetModels
{
    public class TimeLineModel : ITermGetter<TimeLineModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public IQueryable<TimeLineModel> GetTerms(CSOMContext dbContext, int? programId)
        {
            var result = dbContext
                .Terms
                .Where(t => t.ProgramId == programId)
                .Where(t => t.DateStart != null)
                .Where(t => t.DateEnd != null)
                .Select(t => new TimeLineModel()
                {
                    Id = t.TermIdNumber,
                    Name = t.TermTitle,
                    StartDate = t.DateStart.Value,
                    EndDate = t.DateEnd.Value
                });

            return result;
        }
    }
}