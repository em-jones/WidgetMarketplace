using System;
using Store.Application;

namespace Store.StoreFrontStore
{
    public record ItemAddedToShop(Guid ItemId, Guid UserId) : StoreFrontEvent;
}