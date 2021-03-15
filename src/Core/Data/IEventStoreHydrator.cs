using LanguageExt;

namespace Core.Data
{
    public interface IEventStoreHydrator<TId, TStore>
    {
        TryAsync<TStore> Hydrate(TId id);
    }
}