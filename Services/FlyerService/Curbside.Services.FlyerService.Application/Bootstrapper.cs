using Curbside.Services.Shared.CQRS;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using CQRS.Common;
using Curbside.Services.FlyerService.Application.Common.PipelineComponents;

namespace Curbside.Services.FlyerService.Application
{
    public static class Bootstrapper
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.ConfigureCQRS(assembly);
            //services.AddTransient(typeof(IPipelineComponent<,>), typeof(ValidationComponent<,>));
            services.AddValidatorsFromAssembly(assembly);
        }
    }
}
