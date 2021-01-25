using System.Threading.Tasks;

namespace CQRS.Common
{
    /// <summary>
    /// Interface used to implement a dispatcher to execute system requests.
    /// </summary>
    public interface IDispatcher
    {
        /// <summary>
        /// Executes system requests.
        /// </summary>
        /// <typeparam name="TRequest">The type of the request to be executed.</typeparam>
        /// <typeparam name="TResponse">The type of result that will be returned from the request.</typeparam>
        /// <param name="request">The request to be executed.</param>
        /// <returns>The result that will be returned from the request.</returns>
        Task<TResponse> Execute<TRequest, TResponse>(TRequest request) where TRequest : IRequest;
    }
}
