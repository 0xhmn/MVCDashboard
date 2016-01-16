using System.Linq;
using CSOMLocalDataProvider;

namespace Dashboard.Models.Intefaces
{
    /// <summary>
    /// Gettiing the programs available for the viewModel
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface IProgramGetter<out T>
    {
        IQueryable<T> GetPrograms(CSOMContext dbContext, int? programId);
    }
}
