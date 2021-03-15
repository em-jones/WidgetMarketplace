using System;
using System.Collections.Generic;

namespace UserManagement.UserStore
{
    public record UserState(Guid id, 
        string FirstName = "", 
        string LastName = "", 
        string Email = "");
}