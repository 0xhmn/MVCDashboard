using System.Linq;
using CSOMLocalDataProvider;

namespace Dashboard.Models.Intefaces
{
    interface ITermGetter<out T>
    {
        IQueryable<T> GetTerms(CSOMContext dbContext, int? programId);
    }
}
