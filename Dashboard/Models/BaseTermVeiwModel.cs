using System.Linq;
using CSOMLocalDataProvider;
using Dashboard.Models.Intefaces;

namespace Dashboard.Models
{
    public class BaseTermVeiwModel : ITermGetter<BaseTermVeiwModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IQueryable<BaseTermVeiwModel> GetTerms(CSOMContext dbContext, int? programId)
        {
            var result = dbContext
                .Terms
                .Where(t => t.ProgramId == programId)
                .Select(t => new BaseTermVeiwModel()
                {
                    Id = t.TermIdNumber,
                    Name = t.TermTitle
                } );
            return result;
        }
    }
}