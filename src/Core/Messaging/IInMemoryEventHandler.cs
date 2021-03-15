using MediatR;

namespace Core.Messaging
{
    /// <summary>
    /// 
    /// </summary>
    public interface IInMemoryEventHandler<TEvent> : INotificationHandler<TEvent> 
        where TEvent : IEvent
    {
        
    }
}