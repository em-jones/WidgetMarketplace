using System;
using System.Collections.Generic;

namespace Store.StoreFrontStore
{
    public record StoreFrontState(Guid OwnerId, IDictionary<Guid, Item> Inventory);
}