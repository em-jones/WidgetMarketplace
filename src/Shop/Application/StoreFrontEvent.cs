using Core.Messaging;

namespace Store.Application
{
    public record StoreFrontEvent : Message, IEvent;
}