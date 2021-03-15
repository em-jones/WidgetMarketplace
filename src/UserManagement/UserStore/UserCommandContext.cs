using Core.Domain.Types;
using LanguageExt;

namespace UserManagement.UserStore
{
    public record UserCommandContext(UserState State, UserCommand Command, Option<UserEvent> Event) : 
        CommandContext<UserState, UserCommand, UserEvent>(State, Command, Event);
}