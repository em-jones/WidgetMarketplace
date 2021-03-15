using System;

namespace UserManagement.UserStore
{
    internal class UserExistsException : Exception
    {
        public UserExistsException(string empty)
        {
            throw new NotImplementedException();
        }
    }
}