using System.Threading.Tasks;
using LanguageExt;
using LanguageExt.Common;

namespace Core.Data
{
    public interface IProjectionContext<T>
    {
        Task<Result<Unit>> Write(T v);
    }
}