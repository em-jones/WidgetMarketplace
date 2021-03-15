using System;
using Core.Domain;
using Core.Domain.Types;
using LanguageExt;
using Store.Application;

namespace Store.StoreFrontStore
{
    public class StoreFrontEventStore : AbstractMessageStore<StoreFrontEvent, StoreFrontState, StoreFrontCommand, StoreFrontContext>
    {
        public override TryAsync<StoreFrontContext> Handle(StoreFrontContext context, CommandStrategy<StoreFrontContext> strategy)
        {
            throw new NotImplementedException();
        }

        public override Option<StoreFrontState> Get()
        {
            throw new NotImplementedException();
        }
    }
}