using System.Collections.Generic;

namespace Core.Domain
{
    /// <summary>
    /// The <see cref="MessageStore{TEvent}"/> is meant to be used for one of two purposes -
    /// In the case of an <see cref="ICommand"/>
    /// </summary>
    /// <typeparam name="TMessage"></typeparam>
    public record MessageStore<TMessage>(IEnumerable<TMessage> Messages);
}