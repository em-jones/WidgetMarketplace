using Core.Domain.Types;
using LanguageExt;

namespace Store.AccountLedgerStore
{
    public record TransactionContext(AccountLedgerState State, AccountLedgerCommand ItemId, Option<AccountLedgerEvent> Event) 
        : CommandContext<AccountLedgerState, AccountLedgerCommand, AccountLedgerEvent>(State, ItemId, Event);
}