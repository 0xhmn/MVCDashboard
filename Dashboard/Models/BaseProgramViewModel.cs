using System.Linq;
using CSOM.STS.DataAccess;
using Dashboard.Models.Intefaces;

namespace Dashboard.Models
{
    public class BaseProgramViewModel : IProgramGetter<BaseProgramViewModel> 
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IQueryable<BaseProgramViewModel> GetPrograms(CSOMContext dbContext, int? programId)
        {
            return dbContext.PROGRAMS
                .Where(p => p.TERMS_APPLY_ACTIVE.Any())
                .OrderBy(p => p.SORT_ORDER)
                .Select(p => new BaseProgramViewModel()
                {
                    Id = p.PROGRAM_ID,
                    Name = p.PROGRAM1
                });
        }
    }
}