using System;
using Store.Application;

namespace Store.StoreFrontStore
{
    public record PurchaseItem(DateTime Timestamp, Guid OwnerId, Guid PurchaserId, Guid ItemId) : StoreFrontCommand(Timestamp);
}