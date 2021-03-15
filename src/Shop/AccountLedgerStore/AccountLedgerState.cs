using System;

namespace Store.AccountLedgerStore
{
    public record AccountLedgerState(Guid OwnerId, decimal Funds);
}