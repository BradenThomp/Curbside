using Curbside.Services.Shared.CQRS.Commands;
using Curbside.Services.Shared.CQRS.Queries;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace Curbside.Services.Shared.CQRS
{
    public static class Bootstrapper
    {
        public static void ConfigureCQRS(this IServiceCollection services, Assembly assembly)
        {
            services.ResolveHanders(assembly, typeof(ICommandHandler<>));
            services.ResolveHanders(assembly, typeof(ICommandHandler<,>));
            services.ResolveHanders(assembly, typeof(IQueryHandler<,>));

            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();
        }

        private static void ResolveHanders(this IServiceCollection services, Assembly assembly, Type handlerInterface)
        {
            var types = assembly.GetTypes();

            var handlers = assembly.GetTypes().Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterface));

            foreach(var handler in handlers)
            {
                services.AddScoped(handler.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterface), handler);
            }
        }
    }
}
