using Core.Messaging;

namespace Store.AccountLedgerStore
{
    public record AccountLedgerEvent : Message, IEvent;
}