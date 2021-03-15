using System;
using System.Diagnostics;

namespace Core.Messaging
{

    /// <summary>
    /// The <see cref="HandlerException" /> type is used to notify clients of a failure to complete the handling of a
    /// given message. If the message is a command, it will be held as a part of a DeadLetter message store
    /// </summary>
    public class HandlerException : Exception
    {
        private static string CallerName()
            => (new StackTrace()).GetFrame(1)?.GetMethod()?.DeclaringType?.ToString();

        public HandlerException() : base ($"{CallerName()} failed")
        {
        }

        public HandlerException(Exception exception) 
            : base($"{CallerName()} failed", exception) {}
    }
}
