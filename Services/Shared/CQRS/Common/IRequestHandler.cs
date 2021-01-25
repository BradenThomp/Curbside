using System.Threading.Tasks;

namespace CQRS.Common
{
    /// <summary>
    /// Handler for executing IRequests.
    /// </summary>
    /// <typeparam name="TRequest">The request to be handled.</typeparam>
    /// <typeparam name="TResponse">The response that the handler returns.</typeparam>
    public interface IRequestHandler<TRequest, TResponse> where TRequest : IRequest
    {
        public Task<TResponse> Handle(TRequest command);
    }
}
