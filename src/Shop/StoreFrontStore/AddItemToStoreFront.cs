using System;
using Core.Domain.Types;
using Core.Messaging;

namespace Store.StoreFrontStore
{
    public record AddItemToStoreFront
        (Guid ItemId, Guid StoreFrontId, Amount Amount) 
            : ItemCommand, ICommand<StoreFrontState>;
}