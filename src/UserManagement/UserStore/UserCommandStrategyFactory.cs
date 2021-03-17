using System;
using System.Collections.Generic;
using Core.Domain;
using Core.Domain.Types;
using LanguageExt;

namespace UserManagement.UserStore
{
    public class UserCommandStrategyFactory : AbstractCommandStrategyFactory, ICommandStrategyFactory<UserCommandContext>
    {
        private static IDictionary<Type, CommandStrategy<UserCommandContext>> Handlers = _handlers(new List<(Type, CommandStrategy<UserCommandContext>)>
        {
            (typeof(CreateUser), CreateUserStrategy.Strategy)
        });

        public Option<CommandStrategy<UserCommandContext>> Get<TCommand>() => Handlers[typeof(TCommand)];
    }
}