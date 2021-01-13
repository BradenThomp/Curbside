using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Curbside.Services.Shared.CQRS.Commands
{
    public interface ICommandDispatcher
    {
        Task<ICommandResult> Execute<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
