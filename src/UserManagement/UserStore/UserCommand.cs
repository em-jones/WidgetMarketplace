using System;
using Core.Messaging;

namespace UserManagement.UserStore
{
    public record UserCommand(DateTime Timestamp) : Command(Timestamp);
}