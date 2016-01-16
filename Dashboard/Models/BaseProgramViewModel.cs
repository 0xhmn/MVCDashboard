using System.Linq;
using CSOMLocalDataProvider;
using Dashboard.Models.Intefaces;

namespace Dashboard.Models
{
    public class BaseProgramViewModel : IProgramGetter<BaseProgramViewModel> 
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IQueryable<BaseProgramViewModel> GetPrograms(CSOMContext dbContext, int? programId)
        {
            return dbContext.Programs
                .Select(p => new BaseProgramViewModel()
                {
                    Id = p.ProgramId,
                    Name = p.ProgramTitle
                });
        }
    }
}