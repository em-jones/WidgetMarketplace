using System;
using Core.Messaging;
using Store.AccountLedgerStore;

namespace Store.Application
{
    public record GetAccountBalance : Command, ICommand<AccountLedgerState>
    {
        public Guid OwnerId { get; set; }
    }
}