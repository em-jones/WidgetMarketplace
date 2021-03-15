using System;
using System.Threading;
using System.Threading.Tasks;
using Core.Data;
using Core.Domain;
using Core.Domain.Types;
using Core.Messaging;
using LanguageExt;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using Store.AccountLedgerStore;

namespace Store.Application
{
    public class CreditAccountHandler : IInMemoryCommandHandler<CreditAccount, AccountLedgerState>
    {
        private ILogger<CreditAccountHandler> _logger;
        private IEventStoreHydrator<Guid, AccountLedgerEventStore> _hydrator;
        private Option<CommandStrategy<AccountLedgerContext>> _strategy;

        public CreditAccountHandler(ICommandStrategyFactory<AccountLedgerContext> strategyFactory, 
            IEventStoreHydrator<Guid, AccountLedgerEventStore> hydrator, 
            ILogger<CreditAccountHandler> logger)
        {
            _strategy = strategyFactory.Get<CreditAccount>();
            _hydrator = hydrator;
            _logger = logger;
        }

        // todo - add codegen to roadmap
        public Task<AccountLedgerState> Handle(CreditAccount request, CancellationToken cancellationToken) =>
            _strategy.MapAsync(strategy => GetStoreAndApply(strategy, request)).
                Match(r => r.Match(ledgerState => ledgerState, e => throw e),
                () => throw new InvalidCommandException(request));

        private Task<Result<AccountLedgerState>>
            GetStoreAndApply(CommandStrategy<AccountLedgerContext> strategy, CreditAccount request) =>
            _hydrator.Hydrate(request.AccountOwnerId)
                .Bind(store => store.Handle(new(null, request, null), strategy))
                .Map(result => result.State
                ).Invoke();

    }

}