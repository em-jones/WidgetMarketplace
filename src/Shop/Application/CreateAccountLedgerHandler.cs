using System.Threading;
using System.Threading.Tasks;
using Core.Messaging;
using Store.AccountLedgerStore;

namespace Store.Application
{
    public class CreateAccountLedgerHandler : IInMemoryCommandHandler<CreateAccountLedger, AccountLedgerState>
    {
        public Task<AccountLedgerState> Handle(CreateAccountLedger request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}