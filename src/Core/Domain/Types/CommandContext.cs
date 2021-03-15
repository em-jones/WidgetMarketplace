using LanguageExt;

namespace Core.Domain.Types
{
    public record CommandContext<TState, TCommand, TEvent>(TState State, TCommand Command, Option<TEvent> Event = default);
}