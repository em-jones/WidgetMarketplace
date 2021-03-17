using System;

namespace Store.AccountLedgerStore
{
    public record Transaction(Guid SellerId, Guid BuyerId, Guid ItemId, TransactionType Type)
        : AccountLedgerCommand;
}