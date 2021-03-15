using System.Threading.Tasks;
using LanguageExt.Common;

namespace Core.Domain
{
    
    /// <summary>
    /// The <see cref="IWriter{TEvent,TResult}"/> type is responsible for knowing how to make use of
    /// events given the responsibility of its clients.
    /// Its clients should be Application-Layer types that are responsible for orchestrating the flow of data.
    /// </summary>
    /// <typeparam name="TEvent"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public interface IWriter<TEvent, TResult>
    {
        Task<Result<TResult>> WriteAsync(TEvent e);
    }
}