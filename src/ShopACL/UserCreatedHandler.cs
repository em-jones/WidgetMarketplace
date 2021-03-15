using System.Threading;
using System.Threading.Tasks;
using Core.Messaging;
using LanguageExt;
using Microsoft.Extensions.Logging;
using Store.AccountLedgerStore;
using UserManagement.UserStore;

namespace ShopACL
{
    public class UserCreatedHandler : IInMemoryEventHandler<UserCreated>
    {
        private ILogger<UserCreatedHandler> _logger;
        private IInMemoryBus _bus;

        public UserCreatedHandler(ILogger<UserCreatedHandler> logger, IInMemoryBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        public Task Handle(UserCreated notification, CancellationToken cancellationToken) =>
            Translate(notification)
                .MapAsync(c => _bus.Send(c, cancellationToken))
                .Invoke();

        private Try<CreateAccountLedger> Translate(UserCreated userCreated) => () =>
            new CreateAccountLedger(userCreated.Timestamp, userCreated.Id);
    }
}