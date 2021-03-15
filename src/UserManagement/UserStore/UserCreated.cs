using System;
using Core.Messaging;

namespace UserManagement.UserStore
{
    public record UserCreated(Guid Id, string FirstName, string LastName, string Email, DateTime Timestamp) 
        : UserEvent(Id, Timestamp), IEvent;
}