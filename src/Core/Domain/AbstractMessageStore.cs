using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain.Types;
using Core.Messaging;
using LanguageExt;

namespace Core.Domain
{
    public abstract class AbstractMessageStore<TEvent, TState, TCommand, TContext> 
        where TEvent : Message
        where TContext : CommandContext<TState, TCommand, TEvent>
    {
        protected MessageStore<TEvent> Store;
        
        /// <summary>
        /// The <see cref="Messages"/> property is used for returning an ordered stream of messages relevant to
        /// a given entity
        /// </summary>
        /// <returns></returns>
        private IEnumerable<TEvent> Messages() => Store.Messages.OrderByDescending(m => m.Timestamp);

        protected TState CurrentState(TState seed) => Messages().AsEntity(Reducer, seed);
        
        protected Func<TState, TEvent, TState> Reducer;

        protected TryAsync<TContext> ApplyStrategy(TContext context, CommandStrategy<TContext> s)  =>  s(context);

        protected TContext RecordEvent(TContext c) => c.Event.Match(e =>
            {
                Store.Messages.ToList().Add(e);
                return c;
            }, () => c);

        public abstract TryAsync<TContext> Handle(
            TContext context,
            CommandStrategy<TContext> strategy
        );
        
        public abstract Option<TState> Get();
    }
}