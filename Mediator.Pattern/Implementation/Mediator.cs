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

        public TResult Dispatch<TArg, TResult>(TArg query) where TArg : IArgument<TResult>
        {
            if (_handlersByType.TryGetValue(query.GetType(), out var handler))
            {
                return (handler as IHandler<TArg, TResult>).Handle(query);
            }
            return default(TResult);
        }

        public void Dispatch<TArg>(TArg command) where TArg : IArgument
        {
            if(_handlersByType.TryGetValue(command.GetType(), out var handler))
            {
                (handler as IHandler<TArg>).Handle(command);
            }
        }

        public void Register<TArg, TResult>(IHandler<TArg, TResult> handler) where TArg : IArgument<TResult>
        {
            _handlersByType[typeof(TArg)] = handler;
        }

        public void Register<TArg>(IHandler<TArg> handler) where TArg : IArgument
        {
            _handlersByType[typeof(TArg)] = handler;
        }

    }
}
