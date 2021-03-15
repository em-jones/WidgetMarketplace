using System.Threading.Tasks;

namespace Core.Domain
{
    public interface ICommandStrategy<TCommandContext>
    {
        Task<TCommandContext> Apply(TCommandContext c);
    }
}