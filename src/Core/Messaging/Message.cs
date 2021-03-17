using System;

namespace Core.Messaging
{
    public record Message
    {
        public DateTime Timestamp { get; set; } = DateTime.Now.ToUniversalTime();
    }
    
}