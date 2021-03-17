using System.Collections.Generic;
using LanguageExt;

namespace Core.Data
{
    public interface IEventStoreContext<TId, TEvent> : IDataContext<IEnumerable<TEvent>>
    {
        TryAsync<IEnumerable<TEvent>> Get(TId id);
    }
}