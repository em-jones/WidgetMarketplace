using System;

namespace Store.AccountLedgerStore
{
    public record DebitAccount(Guid AccountOwnerId, Guid ProductSellerId, Guid ItemId) 
        : Transaction(ProductSellerId, AccountOwnerId, ItemId, TransactionType.DEBIT);
}