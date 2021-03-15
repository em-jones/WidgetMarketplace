using System;
using Core.Messaging;
using Store.StoreFrontStore;

namespace Store.Application
{
    public record GetStock(DateTime Timestamp, Guid OwnerId) : Command(Timestamp), ICommand<StoreFrontState>;
}