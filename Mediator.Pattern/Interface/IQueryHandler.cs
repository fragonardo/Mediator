using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Pattern.Interface
{
    public interface IQueryHandler<TQuery, TResult> : IHandler where TQuery : IQuery
    {
        TResult Handle(TQuery query);
    }
}
