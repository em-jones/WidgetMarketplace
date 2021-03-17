using System;
using System.Threading;
using System.Threading.Tasks;
using Core;
using Core.Data;
using Core.Domain;
using Core.Domain.Types;
using Core.Messaging;
using LanguageExt;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using UserManagement.UserStore;

namespace UserManagement.Application
{
    // ReSharper disable once UnusedType.Global
    public class CreateUserHandler : IInMemoryCommandHandler<CreateUser, UserState>
    {
        private  Option<CommandStrategy<UserCommandContext>> _strategy;
        private readonly ILogger<CreateUserHandler> _logger;
        private readonly IEventStoreHydrator<Guid, UserEventStore> _hydrator;
        private readonly IInMemoryBus _bus;
        public CreateUserHandler(ILogger<CreateUserHandler> logger, 
            IEventStoreHydrator<Guid, UserEventStore> hydrator, 
            ICommandStrategyFactory<UserCommandContext> commandStrategyFactory, 
            IInMemoryBus bus)
        {
            _strategy = commandStrategyFactory.Get<CreateUser>();
            _logger = logger;
            _hydrator = hydrator;
            _bus = bus;
        }

        public Task<UserState> Handle(CreateUser request, CancellationToken cancellationToken) =>
            _strategy.MapAsync(s => WhenStrategyExists(s, request))
                .Match(
                    r => r.Match(u => u, e => throw e), 
                    () => throw new InvalidCommandException(request));
        
        private Task<Result<UserState>> WhenStrategyExists(CommandStrategy<UserCommandContext> strategy,
            CreateUser request) =>
            _hydrator
                .Hydrate(Guid.NewGuid())
                .Bind(store => store.Handle(new UserCommandContext {Command =  request}, strategy))
                .Map(result => result.Event.Match(e =>
                {
                    _bus.Publish(e);
                    return result.State;
                }, () => result.State)).Invoke();
        
    }

}