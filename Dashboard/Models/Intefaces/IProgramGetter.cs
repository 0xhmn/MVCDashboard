using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSOM.STS.DataAccess;

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
