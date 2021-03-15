using System;
using Core.Messaging;

namespace UserManagement.UserStore
{
    public record GetUser(Guid Id) : UserCommand(DateTime.Now.ToUniversalTime()), ICommand<UserState>;
}