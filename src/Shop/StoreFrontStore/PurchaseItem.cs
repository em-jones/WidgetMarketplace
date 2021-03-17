using System;
using Store.Application;

namespace Store.StoreFrontStore
{
    public record PurchaseItem(Guid OwnerId, Guid PurchaserId, Guid ItemId) : StoreFrontCommand;
}