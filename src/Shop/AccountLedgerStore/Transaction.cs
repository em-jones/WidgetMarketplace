using System;

namespace Store.AccountLedgerStore
{
    public record Transaction(DateTime Timestamp, Guid SellerId, Guid BuyerId, Guid ItemId, TransactionType Type)
        : AccountLedgerCommand(Timestamp);
}