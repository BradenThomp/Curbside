using CQRS.Common;

namespace CQRS.Commands
{
    /// <summary>
    /// Interface for a command. Commands change system state and should not query data (Create Update Delete).
    /// However, commands can and should return a result that indicates the systems state.
    /// </summary>
    public interface ICommand : IRequest
    {
    }
}
