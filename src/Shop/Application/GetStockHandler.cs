using System;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using Core.Data;
using Core.Messaging;
using Microsoft.Extensions.Logging;
using Store.StoreFrontStore;

namespace Store.Application
{
    public class GetStockHandler : IInMemoryCommandHandler<GetStock, StoreFrontState>
    {
        private ILogger<GetBalanceHandler> _logger;
        private IEventStoreHydrator<Guid, StoreFrontEventStore> _hydrator;

        public GetStockHandler(ILogger<GetBalanceHandler> logger, IEventStoreHydrator<Guid, StoreFrontEventStore> hydrator)
        {
            _logger = logger;
            _hydrator = hydrator;
        }

        public Task<StoreFrontState> Handle(GetStock request, CancellationToken cancellationToken) =>
            _hydrator.Hydrate(request.OwnerId)
                .Bind(store => store.Get().ToTryAsync())
                .Match(state => state, _ => new StoreFrontState(Guid.Empty, ImmutableDictionary<Guid, Item>.Empty));

    }
}