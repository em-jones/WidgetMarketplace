using Core.Domain.Types;

namespace Store.StoreFrontStore
{
    public record Item(string Description, Amount Amount, ItemType Type);
}