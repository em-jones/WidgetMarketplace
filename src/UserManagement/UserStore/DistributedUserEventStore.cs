using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Messaging;
using LanguageExt;
using Orleans;
using Orleans.Runtime;

namespace UserManagement.UserStore
{
    public interface IDistributedUserEventStore : IGrainWithGuidKey
    {
        Task<UserState> Get();
        Task<UserState> Handle(UserCommandContext context);
    }
    public class DistributedUserEventStore : Grain, IDistributedUserEventStore
    {
        private readonly IPersistentState<IEnumerable<UserEvent>> _state;
        private readonly IInMemoryBus _bus;

        public DistributedUserEventStore(
            [PersistentState(stateName: "user", storageName: "users")]
            IPersistentState<IEnumerable<UserEvent>> state, 
            IInMemoryBus bus)
        {
            _state = state;
            _bus = bus;
        }

        public Task<UserState> Get()
        {
            throw new System.NotImplementedException();
        }

        public Task<UserState> Handle(UserCommandContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}