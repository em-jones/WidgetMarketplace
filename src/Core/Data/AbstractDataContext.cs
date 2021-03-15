using System;
using System.Collections.Concurrent;
using LanguageExt;

namespace Core.Data
{
    public abstract class AbstractDataContext<T> : IDataContext<T> 
    {
        protected ConcurrentDictionary<Guid, T> Data;

        public abstract TryAsync<T> Get(Guid id);
    }
}