using System;
using System.Linq;
using CSOMLocalDataProvider;
using Dashboard.Models.Intefaces;

namespace Dashboard.Models.WidgetModels
{
    public class CounterModel : IProgramGetter<CounterModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfApplications { get; set; }
        public bool? IsSelected { get; set; }

        public IQueryable<CounterModel> GetPrograms(CSOMContext dbContext, int? programId)
        {
            var programs = dbContext.Programs
                .Select(p => new CounterModel()
                {
                    Id = p.ProgramId,
                    Name = p.ProgramTitle,
                    NumberOfApplications = 10,    // ToDo: make a column for number of the appliations
                    IsSelected = (p.ProgramId == programId)
                });
            Console.WriteLine(programs);
            return programs;
        }
    }
}