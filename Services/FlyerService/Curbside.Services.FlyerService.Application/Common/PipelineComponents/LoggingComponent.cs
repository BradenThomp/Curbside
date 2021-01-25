using CQRS.Common;
using System;
using System.Threading.Tasks;

namespace Curbside.Services.FlyerService.Application.Common.PipelineComponents
{
    public class LoggingComponent<TRequest, TResponse> : IPipelineComponent<TRequest, TResponse>
    {
        public Func<TRequest, Task<TResponse>> Next { get; set; }

        public async Task<TResponse> Handle(TRequest request)
        {
            Console.WriteLine("Logging...");

            return await Next.Invoke(request);
        }
    }
}
