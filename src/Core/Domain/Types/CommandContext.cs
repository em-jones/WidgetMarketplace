using LanguageExt;

namespace Core.Domain.Types
{
    public record CommandContext<TState, TCommand, TEvent>
    {
        public TState State { get; set; }   
        public TCommand Command { get; set; }
        public Option<TEvent> Event { get; set; }
    }
}