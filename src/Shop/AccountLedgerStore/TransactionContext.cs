using Core.Domain.Types;
using LanguageExt;

namespace Store.AccountLedgerStore
{
    public record TransactionContext : CommandContext<AccountLedgerState, AccountLedgerCommand, AccountLedgerEvent>;
}