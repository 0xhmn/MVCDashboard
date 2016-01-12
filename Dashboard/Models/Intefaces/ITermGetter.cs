using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSOM.STS.DataAccess;

namespace Dashboard.Models.Intefaces
{
    interface ITermGetter<out T>
    {
        IQueryable<T> GetTerms(CSOMContext dbContext, int? programId);
    }
}
