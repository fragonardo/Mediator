using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Pattern.Interface
{
    public interface IHandler
    {

    }

    public interface IHandler<TArg> : IHandler where TArg : IArgument
    {
        void Handle(TArg command);
    }

    public interface IHandler<TArg, TResult> : IHandler where TArg : IArgument<TResult>
    {
        TResult Handle(TArg command);
    }
}
