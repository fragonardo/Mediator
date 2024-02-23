using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Pattern.Interface
{
    public interface ICommandHandler<TCommand> : IHandler where TCommand : ICommand
    {
        void Handle(ICommand command);
    }
}
