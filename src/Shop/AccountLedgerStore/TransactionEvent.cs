using Core.Messaging;

namespace Store.AccountLedgerStore
{
    public record TransactionEvent : Message, IEvent;
}