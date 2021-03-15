using System;

namespace Store.AccountLedgerStore
{
    public record DebitAccount(DateTime Timestamp, Guid AccountOwnerId, Guid ProductSellerId, Guid ItemId) 
        : Transaction(Timestamp, ProductSellerId, AccountOwnerId, ItemId, TransactionType.DEBIT);
}