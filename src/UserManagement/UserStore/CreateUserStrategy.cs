using System;
using Core.Domain.Types;
using Core.Messaging;
using LanguageExt;

namespace UserManagement.UserStore
{
    internal static class CreateUserStrategy
    {
        private static Func<UserState, UserCommandContext> 
            AttemptCommand(UserCommandContext context, CreateUser command) =>
            s => context with {Event = CreateUserIfNoneExist(s, command)};
        private static UserCreated CreateUserIfNoneExist(Option<UserState> user, CreateUser command) =>
            user.Match(
                s => throw new UserExistsException($"User with email {s.Email} already exists"),
                () => new UserCreated
                {
                    Id = Guid.NewGuid(), FirstName = command.FirstName, LastName = command.LastName,
                    Email = command.Email, Timestamp = command.Timestamp
                }
            );

        internal static readonly CommandStrategy<UserCommandContext> Strategy = context => context.Command switch
        {
            CreateUser command => command.FindIfUserExists
                .Map(AttemptCommand(context, command)),
            var c => throw new InvalidCommandException(c)
        };
    }
}