using System;
using System.Collections.Generic;
using System.Linq;
using Core.Data;
using LanguageExt;
using Microsoft.Extensions.Logging;

namespace UserManagement.UserStore
{
    /// <summary>
    /// The Hydrator type will be responsible for initializing a store + providing it its dependencies
    /// </summary>
    public class Hydrator : IEventStoreHydrator<Guid, UserEventStore>
    {
        private readonly ILogger<IEventStoreHydrator<Guid, UserEventStore>> _logger;
        private readonly IDataContext<IEnumerable<UserEvent>> _storeContext;
        private readonly Func<UserState, UserEvent, UserState> _reducer;

        public Hydrator(ILogger<IEventStoreHydrator<Guid, UserEventStore>> logger, 
            IDataContext<IEnumerable<UserEvent>> storeContext,
            Func<UserState, UserEvent, UserState> reducer
            )
        {
            _logger = logger;
            _storeContext = storeContext;
            _reducer = reducer;
        }

        public TryAsync<UserEventStore> Hydrate(Guid userId) => 
            _storeContext.Get(userId)
                .Map(events => events switch
                {
                    { } list when !list.Any() => new UserEventStore(events.Append(new UserInitialized(userId)), _reducer),
                    { } list when list.Any() => new UserEventStore(events, _reducer)
                });
    }
}