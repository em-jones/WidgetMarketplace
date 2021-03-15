using System;

namespace UserManagement.UserStore
{
    public record UserInitialized(Guid Id) : UserEvent(Id, DateTime.Now);
}