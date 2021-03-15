using System.Threading;
using System.Threading.Tasks;
using Core.Messaging;
using Store.AccountLedgerStore;
using Store.StoreFrontStore;

namespace UserACL
{
    public class ItemSoldHandler : IInMemoryEventHandler<ItemSold>
    {
        public Task Handle(ItemSold notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}