using System;
using Core.Messaging;

namespace UserManagement.UserStore
{
    [Serializable]
    public record UserCreated
        : UserEvent, IEvent
    {
        public string FirstName { get; set; }   
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}