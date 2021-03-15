using System;
using Core.Messaging;

namespace Store.StoreFrontStore
{
    public record ItemSold(DateTime Timestamp, Guid SellerId, Guid ItemId) : IEvent;
}