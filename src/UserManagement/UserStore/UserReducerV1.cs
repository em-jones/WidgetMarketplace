using System;

namespace UserManagement.UserStore
{
    public static class UserReducerV1
    {
        public static readonly Func<UserState, UserEvent, UserState> Reducer = (s, e) => e switch
        {
            UserCreated c => s with {Id = c.Id, Email = c.Email, FirstName = c.FirstName, LastName = c.LastName},
            _ => throw new ArgumentOutOfRangeException(nameof(e), e, null)
        };
    }
}