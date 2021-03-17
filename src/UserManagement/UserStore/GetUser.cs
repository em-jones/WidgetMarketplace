using System;
using Core.Messaging;

namespace UserManagement.UserStore
{
    public record GetUser(Guid Id) : UserCommand, ICommand<UserState>
    {
        public GetUser() : this(Guid.Empty)
        {
           Timestamp = DateTime.Now.ToUniversalTime(); 
        }
    }
}