using System;
using System.Reflection;
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
        public static void AddMediator<T>(this IServiceCollection services) =>
            services.AddMediatR(typeof(T).GetTypeInfo().Assembly);
    }

}