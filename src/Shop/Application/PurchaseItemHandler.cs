using System;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using Core.Data;
using Core.Domain;
using Core.Domain.Types;
using Core.Messaging;
using LanguageExt;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using Store.StoreFrontStore;

namespace Store.Application
{
    public class PurchaseItemHandler : IInMemoryCommandHandler<PurchaseItem, StoreFrontState>
    {
        private IEventStoreHydrator<Guid, StoreFrontEventStore> _hydrator;
        private Option<CommandStrategy<StoreFrontContext>> _strategy;
        private ILogger<PurchaseItemHandler> _logger;
        private IInMemoryBus _bus;

        public PurchaseItemHandler(IInMemoryBus inMemoryBus, 
            ICommandStrategyFactory<StoreFrontContext> commandStrategyFactory, 
            ILogger<PurchaseItemHandler> logger, IInMemoryBus bus, IEventStoreHydrator<Guid, StoreFrontEventStore> hydrator)
        {
            _strategy = commandStrategyFactory.Get<PurchaseItem>();
            _logger = logger;
            _bus = bus;
            _hydrator = hydrator;
        }

        public Task<StoreFrontState> Handle(PurchaseItem request, CancellationToken cancellationToken) =>
            _strategy.MapAsync(strategy => WhenStrategyExists(strategy, request))
                .Match(state => state.Match(s => s, e => throw e), 
                    () => throw new InvalidCommandException(request));

        private Task<Result<StoreFrontState>> WhenStrategyExists(CommandStrategy<StoreFrontContext> strategy, PurchaseItem request) =>
            _hydrator
                .Hydrate(request.OwnerId)
                .Bind(store => store.Handle(new StoreFrontContext{Command = request}, strategy))
                .Map(result => result.Event.Match(e =>
                {
                    _bus.Publish(e);
                    return result.State;
                }, () => result.State))
                .Invoke();
    }
}