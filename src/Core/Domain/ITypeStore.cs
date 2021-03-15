using System.Threading.Tasks;
using Orleans;

namespace Core.Domain
{
    public interface ITypeStore<TMessage, TReduction>
    {
        Task<TReduction> Handle(TMessage message);
        Task<TReduction> Get();
    }
}