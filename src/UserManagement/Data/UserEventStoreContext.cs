using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Core;
using Core.Data;
using LanguageExt;
using UserManagement.UserStore;

namespace UserManagement.Data
{
    public class UserEventStoreContext : AbstractDataContext<IEnumerable<UserEvent>>, IEventStoreContext<Guid, UserEvent>
    {
        public UserEventStoreContext()
        {
            Data = new ConcurrentDictionary<Guid, IEnumerable<UserEvent>>();
        }

        public override TryAsync<IEnumerable<UserEvent>> Get(Guid id) =>
            () => Data.GetOrAdd(id, new ConcurrentBag<UserEvent>())
                .ToResult()
                .ToTask();
    }
}