using System;
using Store.Application;

namespace Store.StoreFrontStore
{
    public record ItemAddedToShop(DateTime Timestamp, Guid ItemId, Guid UserId) : StoreFrontEvent(Timestamp);
}