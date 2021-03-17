using Core.Domain.Types;
using LanguageExt;

namespace UserManagement.UserStore
{
    public record UserCommandContext : CommandContext<UserState, UserCommand, UserEvent>;
}