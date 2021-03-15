using Core.Domain.Types;
using LanguageExt;

namespace Core.Domain
{
    public interface ICommandStrategyFactory<TCommandContext>
    {
        public Option<CommandStrategy<TCommandContext>> Get<TCommand>() ;
    }
}