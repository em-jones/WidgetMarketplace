using System;
using Core;
using Core.Data;
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
        public static void AddUserServices(IServiceCollection services) =>
            services
                .AddSingleton(_ => UserReducerV1.Reducer)
                .AddSingleton<IEventStoreContext<Guid, UserEvent>, UserEventStoreContext>() // Data Client
                .AddSingleton<IEventStoreHydrator<Guid, UserEventStore>, Hydrator>()
                .AddMediator<UserManagementPort>();
    }
}