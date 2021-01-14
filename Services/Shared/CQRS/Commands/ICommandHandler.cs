using System.Threading.Tasks;

namespace Curbside.Services.Shared.CQRS.Commands
{
    /// <summary>
    /// Handler for commands that do not need a result. This interface should be used if possible.
    /// </summary>
    /// <typeparam name="TCommand">The command to be executed asyncronously</typeparam>
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        public Task Handle(TCommand command);
    }

    /// <summary>
    /// Handler for commands that require a result. Returning a result technically violates the CQRS principle, but sometimes a caller needs to know the result right away.
    /// </summary>
    /// <typeparam name="TCommand">The command to be executed asyncronously</typeparam>
    /// <typeparam name="TResponse">The response. Should be an Identifier or Error Message.</typeparam>
    public interface ICommandHandler<TCommand, TResponse> where TCommand : ICommand
    {
        public Task<TResponse> Handle(TCommand command);
    }
}
