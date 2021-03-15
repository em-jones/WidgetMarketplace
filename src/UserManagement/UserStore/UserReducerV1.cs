using System;

namespace UserManagement.UserStore
{
    public class UserReducerV1
    {
        public static Func<UserState, UserEvent, UserState> Reducer = (s, e) => e switch
        {
            UserCreated c => s with {id = c.Id, Email = c.Email, FirstName = c.FirstName, LastName = c.LastName}
        };
    }
}