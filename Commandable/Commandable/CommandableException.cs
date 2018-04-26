using System;
using System.Runtime.Serialization;

namespace Commandable
{
    [Serializable]
    public class CommandableException : Exception
    {
        public CommandableException() { }
        public CommandableException(string message) : base(message) { }
        public CommandableException(string message, Exception inner) : base(message, inner) { }
        protected CommandableException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
