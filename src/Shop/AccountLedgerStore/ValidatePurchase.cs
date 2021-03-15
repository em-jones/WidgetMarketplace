using System;
using Core.Domain.Types;
using Core.Messaging;
using Store.Application;

namespace Store.AccountLedgerStore
{
    public record ValidatePurchase(DateTime Timestamp, Guid AccountOwnerId, Amount Price) 
        : AccountLedgerCommand(Timestamp);

    public record AccountLedgerCommand(DateTime Timestamp) : Command(Timestamp), ICommand<AccountLedgerState>;
}