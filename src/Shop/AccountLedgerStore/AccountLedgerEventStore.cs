using System;
using Core.Domain;
using Core.Domain.Types;
using Core.Messaging;
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

    public record AccountLedgerContext(AccountLedgerState State, AccountLedgerCommand Command, Option<AccountLedgerEvent> Event) : 
        CommandContext<AccountLedgerState, AccountLedgerCommand, AccountLedgerEvent>(
        State, Command, Event);

    public record AccountLedgerEvent(DateTime Timestamp) : Message(Timestamp), IEvent;
}