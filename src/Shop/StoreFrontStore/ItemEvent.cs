using System;
using Core.Messaging;

namespace Store.StoreFrontStore
{
    public record ItemEvent(DateTime Timestamp) : Message(Timestamp);
}