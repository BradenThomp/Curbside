using Curbside.Services.Shared.CQRS;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;

namespace Curbside.Services.FlyerService.Application
{
    public static class Bootstrapper
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.ConfigureCQRS(assembly);
            services.AddValidatorsFromAssembly(assembly);
        }
    }
}
