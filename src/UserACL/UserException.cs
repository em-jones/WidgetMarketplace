using System;
using Core.Messaging;

namespace UserACL
{
    public class UserException : Exception
    {
        public UserException(Command c, string message) : base(message)
        {
            
        }
    }
}