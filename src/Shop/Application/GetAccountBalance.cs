using System;
using Core.Messaging;
using Store.AccountLedgerStore;

namespace Store.Application
{
    public record GetAccountBalance(DateTime Timestamp, Guid OwnerId) : Command(Timestamp), ICommand<AccountLedgerState>;
}