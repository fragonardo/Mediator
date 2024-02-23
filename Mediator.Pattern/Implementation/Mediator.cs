using Mediator.Pattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Pattern.Implementation
{
    public class Mediator : IMediator
    {
        private readonly IDictionary<Type, IHandler> _handlersByType;

        public Mediator()
        {
            _handlersByType = new Dictionary<Type, IHandler>();
        }
        public TResult Dispatch<TQuery, TResult>(TQuery query) where TQuery : IQuery
        {
            if (_handlersByType.TryGetValue(query.GetType(), out var handler))
            {
                return (handler as IQueryHandler<TQuery, TResult>).Handle(query);
            }
            return default(TResult);
        }

        public void Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            if(_handlersByType.TryGetValue(command.GetType(), out var handler))
            {
                (handler as ICommandHandler<TCommand>).Handle(command);
            }
        }

        public void Register<TQuery, TResult>(IQueryHandler<TQuery, TResult> handler) where TQuery : IQuery
        {
            _handlersByType[typeof(TQuery)] = handler;
        }

        public void Register<TCommand>(ICommandHandler<TCommand> handler) where TCommand : ICommand
        {
            _handlersByType[typeof(TCommand)] = handler;
        }
    }
}
