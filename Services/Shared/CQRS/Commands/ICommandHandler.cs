using CQRS.Common;

namespace CQRS.Commands
{
    /// <summary>
    /// Handler for commands that update system state.
    /// </summary>
    /// <typeparam name="TCommand">The command to be executed.</typeparam>
    /// <typeparam name="TResponse">The response. Should be an Identifier or Error Message.</typeparam>
    public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse> where TCommand : ICommand
    {

    }
}
