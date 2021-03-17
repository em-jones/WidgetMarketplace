using Core.Messaging;

namespace Store.AccountLedgerStore
{
    public record AccountLedgerCommand : Command, ICommand<AccountLedgerState>;
}