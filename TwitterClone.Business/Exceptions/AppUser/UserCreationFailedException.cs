using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Business.Exceptions.AppUser
{
    public class UserCreationFailedException : Exception
    {
        public UserCreationFailedException()
        {
        }

        public UserCreationFailedException(string? message) : base(message)
        {
        }

        public UserCreationFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UserCreationFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
