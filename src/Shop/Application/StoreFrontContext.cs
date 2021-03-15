using Core.Domain.Types;
using LanguageExt;
using Store.StoreFrontStore;

namespace Store.Application
{
    public record StoreFrontContext(StoreFrontState State, StoreFrontCommand Command, Option<StoreFrontEvent> Event) : 
        CommandContext<StoreFrontState, StoreFrontCommand, StoreFrontEvent>(State, Command, Event);
}