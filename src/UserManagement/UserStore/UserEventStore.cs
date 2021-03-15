using System;
using System.Collections.Generic;
using Core.Domain;
using Core.Domain.Types;
using LanguageExt;

namespace UserManagement.UserStore
{
    public class UserEventStore : AbstractMessageStore<UserEvent, UserState, UserCommand, UserCommandContext>
    {
        public UserEventStore(IEnumerable<UserEvent> history, Func<UserState, UserEvent, UserState> reducer)
        {
            Reducer = reducer;
            Store = new MessageStore<UserEvent>(history);
        }

        public override TryAsync<UserCommandContext> Handle(
            UserCommandContext context,
            CommandStrategy<UserCommandContext> strategy
        ) =>
            ApplyStrategy(context with {State = CurrentState(new UserState(Guid.Empty))}, strategy)
                .Map(RecordEvent);
        
        public override Option<UserState> Get() => CurrentState(new UserState(Guid.Empty));
    }
}