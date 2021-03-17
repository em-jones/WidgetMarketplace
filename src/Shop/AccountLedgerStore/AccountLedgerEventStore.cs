using System;
using Core.Domain;
using Core.Domain.Types;
using LanguageExt;

namespace Store.AccountLedgerStore
{
    public class AccountLedgerEventStore : AbstractMessageStore<AccountLedgerEvent, AccountLedgerState, AccountLedgerCommand, AccountLedgerContext>
    {
        public override TryAsync<AccountLedgerContext> Handle(AccountLedgerContext context,
            CommandStrategy<AccountLedgerContext> strategy)
            => ApplyStrategy(context with {State = CurrentState(new AccountLedgerState(Guid.Empty, 0))}, strategy);

        public override Option<AccountLedgerState> Get() => CurrentState(new AccountLedgerState(Guid.Empty, 0));
    }
}