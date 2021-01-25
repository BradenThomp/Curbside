using CQRS.Common;
using System;
using System.Threading.Tasks;

namespace Curbside.Services.FlyerService.Application.Common.PipelineComponents
{
    public class ValidationComponent<TRequest, TResponse> : IPipelineComponent<TRequest, TResponse>
    {
        public Func<TRequest, Task<TResponse>> Next { get; set; }

        public async Task<TResponse> Handle(TRequest request)
        {
            Console.WriteLine("Validating...");

            return await Next.Invoke(request);
        }
    }
}
