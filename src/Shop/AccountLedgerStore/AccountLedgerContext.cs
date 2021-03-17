using Core.Domain.Types;
using LanguageExt;

namespace Store.AccountLedgerStore
{
    public record AccountLedgerContext : CommandContext<AccountLedgerState, AccountLedgerCommand, AccountLedgerEvent>;
}