using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curbside.Services.Shared.CQRS.Queries
{
    public interface IQueryDispatcher
    {
        Task<TResult> Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery;
    }
}
