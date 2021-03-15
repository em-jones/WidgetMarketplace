using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Core.Domain
{
    public abstract class AbstractCommandStrategyFactory
    {
        protected static IDictionary<Type, T> _handlers<T>(IEnumerable<(Type, T)> handlers) => handlers
            .Aggregate(new ConcurrentDictionary<Type, T>(), 
                (d, typeAndHandler) => d.TryAdd(typeAndHandler.Item1, typeAndHandler.Item2) ? d : d);
    }
}