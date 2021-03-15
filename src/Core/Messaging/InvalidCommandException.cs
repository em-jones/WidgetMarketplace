using System;
using Core.Domain.Types;

namespace Core.Messaging
{
    /// <summary>
    /// An <see cref="InvalidCommandException"/> is the result of trying to apply a <see cref="CommandStrategy{T}"/>
    /// to a <see cref="ICommand{TResult}"/> of the incorrect type
    /// </summary>
    public class InvalidCommandException : Exception
    {
        public InvalidCommandException(Command c)
        {
            throw new NotImplementedException();
        }
    }
}