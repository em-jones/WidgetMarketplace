using System;
using Core.Messaging;
using LanguageExt.Common;

namespace UserManagement.UserStore
{
    public record GetUserByEmail(string Email) : UserCommand(DateTime.Now.ToUniversalTime()), ICommand<Result<UserState>>;
}