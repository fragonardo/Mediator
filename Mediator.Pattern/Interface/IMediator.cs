using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Pattern.Interface
{
    public interface IMediator
    {
        void Register<TQuery,TResult>(IQueryHandler<TQuery, TResult> handler) where TQuery : IQuery ;
        void Register<TCommand>(ICommandHandler<TCommand> handler) where TCommand : ICommand;

        TResult Dispatch<TQuery, TResult>(TQuery query) where TQuery : IQuery;

        void Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
