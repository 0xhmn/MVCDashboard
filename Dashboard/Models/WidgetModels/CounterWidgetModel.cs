using System;
using System.Linq;
using CSOM.STS.DataAccess;
using Dashboard.Models.Intefaces;

namespace Dashboard.Models.WidgetModels
{
    public class CounterWidgetModel : IProgramGetter<CounterWidgetModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfApplications { get; set; }
        public bool? IsSelected { get; set; }

        public IQueryable<CounterWidgetModel> GetPrograms(CSOMContext dbContext, int? programId)
        {
            var programs = dbContext.PROGRAMS
                .Where(p => p.TERMS_APPLY_ACTIVE.Any())
                .OrderBy(p => p.SORT_ORDER)
                .Select(p => new CounterWidgetModel()
                {
                    Id = p.PROGRAM_ID,
                    Name = p.PROGRAM1,
                    NumberOfApplications = p.APPLICATIONS.Count(),
                    IsSelected = (p.PROGRAM_ID == programId)
                });
            Console.WriteLine(programs);
            return programs;
        }
    }
}