using System;

namespace Core.Messaging
{
    public record Command(DateTime Timestamp) : Message(Timestamp);
}