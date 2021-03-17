using System;
using Core.Messaging;

namespace UserManagement.UserStore
{
    [Serializable]
    public record UserEvent : Message
    {
        public Guid Id { get; set; }
    }
}