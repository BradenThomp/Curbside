using Curbside.Services.Shared.CQRS;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Curbside.Services.FlyerService.Application
{
    public static class Bootstrapper
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.ConfigureCQRS(assembly);
        }
    }
}
