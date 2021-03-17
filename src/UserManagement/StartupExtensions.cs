using System;
using Core;
using Core.Data;
using Core.Domain;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Data;
using UserManagement.UserStore;

namespace UserManagement
{
    /// <summary>
    /// Collection of extension methods used to configure the UserManagement Service
    /// </summary>
    public static class StartupExtensions
    {
        public static IServiceCollection AddUserServices(this IServiceCollection services) =>
            services
                .AddSingleton(_ => UserReducerV1.Reducer)
                .AddSingleton<ICommandStrategyFactory<UserCommandContext>, UserCommandStrategyFactory>()
                .AddSingleton<IEventStoreContext<Guid, UserEvent>, UserEventStoreContext>() // Data Client
                .AddSingleton<IEventStoreHydrator<Guid, UserEventStore>, Hydrator>()
                .AddMediator<UserManagementPort>();
    }
}