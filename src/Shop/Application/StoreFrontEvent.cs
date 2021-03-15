using System;
using Core.Messaging;

namespace Store.Application
{
    public record StoreFrontEvent(DateTime Timestamp) : Message(Timestamp), IEvent;
}