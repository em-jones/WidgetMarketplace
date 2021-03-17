using System;
using System.Reflection;
using Core.Messaging;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    /// <summary>
    /// The <see cref="IocExtensions"/> is meant to be used for supporting the individual services'
    /// ability to bootstrap into a <see cref="IServiceCollection"/>
    /// </summary>
    public static class IocExtensions
    {
        public static IServiceCollection AddMediator<T>(this IServiceCollection services) =>
            services.AddMediatR(typeof(T).GetTypeInfo().Assembly);

        public static IServiceCollection AddInMemoryBus(this IServiceCollection services) =>
            services.AddSingleton<IInMemoryBus, InMemoryMessenger>();
    }

}