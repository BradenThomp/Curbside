using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Curbside.Services.Shared.CQRS.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            var service = this._serviceProvider.GetService(typeof(ICommandHandler<TCommand>)) as ICommandHandler<TCommand>;
            await service.Handle(command);
        }
    }
}
