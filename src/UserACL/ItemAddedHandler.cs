using System.Threading;
using System.Threading.Tasks;
using Core.Messaging;
using LanguageExt;
using Microsoft.Extensions.Logging;
using Store.StoreFrontStore;
using UserManagement.UserListView;

namespace UserACL
{
    public class ItemAddedHandler : IInMemoryEventHandler<ItemAddedToShop>
    {
        private readonly ILogger<ItemAddedHandler> _logger;
        private readonly IInMemoryBus _bus;
        public ItemAddedHandler(ILogger<ItemAddedHandler> logger, IInMemoryBus bus)
        {
            _logger = logger;
            _bus = bus;
        }
        public Task Handle(ItemAddedToShop notification, CancellationToken cancellationToken) => 
            _bus.Send(Translate(notification), cancellationToken);

        private Try<AddItemToUserShop> Translate(ItemAddedToShop e) =>
            () => new AddItemToUserShop();
    }
}