using System;
using System.Threading;
using System.Threading.Tasks;
using Core.Data;
using Core.Domain;
using Core.Messaging;
using Microsoft.Extensions.Logging;
using UserManagement.UserStore;

namespace UserManagement.Application
{
    public class GetUserHandler : IInMemoryCommandHandler<GetUser, UserState>
    {
        private ILogger<GetUserHandler> _logger;
        private IEventStoreHydrator<Guid, UserEventStore> _hydrator;

        public GetUserHandler(ILogger<GetUserHandler> logger, 
            IEventStoreHydrator<Guid, UserEventStore> hydrator,
            ICommandStrategyFactory<UserCommandContext> strategyFactory
            )
        {
            _logger = logger;
            _hydrator = hydrator;
        }

        public Task<UserState> Handle(GetUser request, CancellationToken cancellationToken) =>
            _hydrator.Hydrate(request.Id).Bind(store => store.Get().ToTryAsync())
                .Match(state => state, _ => new (Guid.Empty));
    }

    public class UserDoesNotExistException : Exception
    {
        public UserDoesNotExistException(Guid requestId)
        {
            throw new NotImplementedException();
        }
    }
}