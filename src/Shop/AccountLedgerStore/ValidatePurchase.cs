using System;
using Core.Domain.Types;

namespace Store.AccountLedgerStore
{
    public record ValidatePurchase(Guid AccountOwnerId, Amount Price)
        : AccountLedgerCommand;
}