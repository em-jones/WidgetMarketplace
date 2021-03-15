using System;

namespace Store.AccountLedgerStore
{
    public record CreditAccount(DateTime Timestamp, Guid AccountOwnerId, Guid ProductSellerId, Guid ItemId) 
        : Transaction(Timestamp, AccountOwnerId, ProductSellerId, ItemId, TransactionType.CREDIT);
}