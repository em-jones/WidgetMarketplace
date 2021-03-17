using Core.Domain.Types;
using LanguageExt;
using Store.StoreFrontStore;

namespace Store.Application
{
    public record StoreFrontContext : CommandContext<StoreFrontState, StoreFrontCommand, StoreFrontEvent>;
}