using System;
using Core.Messaging;

namespace UserManagement.UserStore
{
    public record UserEvent(Guid Id, DateTime TimeStamp) : Message(TimeStamp);
}