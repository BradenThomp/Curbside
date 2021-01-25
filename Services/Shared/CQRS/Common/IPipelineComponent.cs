using System;
using System.Threading.Tasks;

namespace CQRS.Common
{
    /// <summary>
    /// Interface for implementing pipeline components that will be called upon executing all requests.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request to be executed by the request handler.</typeparam>
    /// <typeparam name="TResponse">The type of the response returned by the request handler.</typeparam>
    public interface IPipelineComponent<TRequest, TResponse>
    {
        /// <summary>
        /// The next component to be executed in the pipeline.
        /// </summary>
        public Func<TRequest, Task<TResponse>> Next { get; set; }

        /// <summary>
        /// Handles component logic and passes request onto next step.
        /// </summary>
        /// <param name="request">The request to be handled.</param>
        /// <returns>The next component in the pipeline, or the response.</returns>
        public Task<TResponse> Handle(TRequest request);

    }
}
