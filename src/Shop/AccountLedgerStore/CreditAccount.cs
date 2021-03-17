using System;

namespace Store.AccountLedgerStore
{
    public record CreditAccount(Guid AccountOwnerId, Guid ProductSellerId, Guid ItemId) 
        : Transaction(AccountOwnerId, ProductSellerId, ItemId, TransactionType.CREDIT);
}