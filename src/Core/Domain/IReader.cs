using System.Threading.Tasks;
using LanguageExt.Common;

namespace Core.Domain
{
    public interface IReader<TKey, TReturn>
    {
        Task<Result<TReturn>> ReadAsync(TKey key);
    }
}