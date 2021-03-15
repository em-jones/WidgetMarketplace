using System.Collections.Generic;
using LanguageExt;

namespace Core.Data
{
    public interface IEventStoreContext<TId, TEvent>
    {
        TryAsync<IEnumerable<TEvent>> Get(TId id);
    }
}