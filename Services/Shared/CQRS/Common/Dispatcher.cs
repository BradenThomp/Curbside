using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Common
{
    /// <summary>
    /// Dispatches and routes system commands through a series of pipeline steps.
    /// Implements <see cref="IDispatcher"/>
    /// </summary>
    public class Dispatcher : IDispatcher
    {
        /// <summary>
        /// Service provider to resolve handlers.
        /// </summary>
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="serviceProvider">Service provider to resolve handlers.</param>
        public Dispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// This implementation of <see cref="IDispatcher.Execute{TRequest, TResponse}(TRequest)"/>
        /// routes all requests through a chain of command pipeline, and then executes the request
        /// with the resolved handler.
        /// </summary>
        public async Task<TResponse> Execute<TRequest, TResponse>(TRequest request) where TRequest : IRequest
        {
            var requestHandler = this._serviceProvider.GetService(typeof(IRequestHandler<TRequest, TResponse>)) as IRequestHandler<TRequest, TResponse>;

            var pipelineComponents = _serviceProvider.GetService(typeof(IEnumerable<IPipelineComponent<TRequest, TResponse>>)) 
                as IEnumerable<IPipelineComponent<TRequest, TResponse>>;

            // If there is no components available, just execute the command.
            if(pipelineComponents.Count() == 0)
            {
                return await requestHandler.Handle(request);
            }

            // Build recursive chain of command.
            for(int i = 1; i < pipelineComponents.Count(); i++)
            {
                var toInvoke = pipelineComponents.ElementAt(i);
                pipelineComponents.ElementAt(i - 1).Next = request => toInvoke.Handle(request);
            }
            pipelineComponents.Last().Next = request => requestHandler.Handle(request);

            // Execute pipeline.
            return await pipelineComponents.First().Handle(request);
        }

    }
}
