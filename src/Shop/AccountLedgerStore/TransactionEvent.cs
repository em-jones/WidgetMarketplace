using System;
using Core.Messaging;

namespace Store.AccountLedgerStore
{
    public record TransactionEvent (DateTime Timestamp) : Message(Timestamp), IEvent;
}