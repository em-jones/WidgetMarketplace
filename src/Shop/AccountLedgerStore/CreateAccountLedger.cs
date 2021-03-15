using System;
using Core.Messaging;

namespace Store.AccountLedgerStore
{
    public record CreateAccountLedger(DateTime Timestamp, Guid UserId) : ICommand<AccountLedgerState>;
}