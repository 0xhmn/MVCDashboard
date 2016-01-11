using System.Linq;
using CSOM.STS.DataAccess;
using Dashboard.Models.Intefaces;

namespace Dashboard.Models
{
    public class BaseTermVeiwModel : ITermGetter<BaseTermVeiwModel>
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public IQueryable<BaseTermVeiwModel> GetTerms(CSOMContext dbContext, int? termId)
        {
            var result = dbContext
                .TERMS_APPLY_ACTIVE
                .Where(t => t.PROGRAM_ID == termId)
                .Select(t => new BaseTermVeiwModel()
                {
                    Id = t.TERM_ID,
                    Name = t.TERM.TERM1
                } );
            return result;
        }


    }
}