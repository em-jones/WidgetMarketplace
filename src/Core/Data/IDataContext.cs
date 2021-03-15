using System;
using LanguageExt;

namespace Core.Data
{
    public interface IDataContext<T>
    {
        TryAsync<T> Get(Guid id);
    }
}