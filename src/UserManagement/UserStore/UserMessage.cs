using System;
using Core.Messaging;

namespace UserManagement.UserStore
{
    public record UserMessage(DateTime Timestamp) : Message(Timestamp);
}