using System.Threading;
using System.Threading.Tasks;
using Core.Messaging;
using Store.StoreFrontStore;

namespace Store.Application
{
    public class AddItemToShopHandler : IInMemoryCommandHandler<AddItemToStoreFront, StoreFrontState>
    {
        public Task<StoreFrontState> Handle(AddItemToStoreFront request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}