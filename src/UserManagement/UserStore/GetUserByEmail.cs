using Core.Messaging;
using LanguageExt.Common;

namespace UserManagement.UserStore
{
    public record GetUserByEmail(string Email) : UserCommand, ICommand<Result<UserState>>;
}