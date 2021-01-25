using CQRS.Common;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace Curbside.Services.Shared.CQRS
{
    /// <summary>
    /// Bootstrapper to setup the CQRS Framework.
    /// </summary>
    public static class Bootstrapper
    {
        /// <summary>
        /// Resolves all handlers and adds dispatcher.
        /// </summary>
        /// <param name="services">The Service Collection.</param>
        /// <param name="assembly">The assembly to scan for handlers.</param>
        public static void ConfigureCQRS(this IServiceCollection services, Assembly assembly)
        {
            services.ResolveHanders(assembly, typeof(IRequestHandler<,>));

            services.AddScoped<IDispatcher, Dispatcher>();
        }

        /// <summary>
        /// Resolves all handlers.
        /// </summary>
        /// <param name="services">The service collection to add to.</param>
        /// <param name="assembly">The assembly to scan for handlers.</param>
        /// <param name="handlerInterface">The handler type to resolve.</param>
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
