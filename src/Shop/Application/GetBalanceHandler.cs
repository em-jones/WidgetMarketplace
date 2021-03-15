using System;
using System.Threading;
using System.Threading.Tasks;
using Core.Data;
using Core.Messaging;
using Microsoft.Extensions.Logging;
using Store.AccountLedgerStore;

namespace Store.Application
{
    public class GetBalanceHandler : IInMemoryCommandHandler<GetAccountBalance, AccountLedgerState>
    {
        private ILogger<GetBalanceHandler> _logger;
        private IEventStoreHydrator<Guid, AccountLedgerEventStore> _hydrator;

        public Task<AccountLedgerState> Handle(GetAccountBalance request, CancellationToken cancellationToken) =>
            _hydrator.Hydrate(request.OwnerId)
                .Bind(store => store.Get().ToTryAsync())
                .Match(state => state, _ => new AccountLedgerState(Guid.Empty, 0));

    }
}