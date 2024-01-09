using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Business.Exceptions.Auth
{
    internal class UsernameOrPasswordWrongException : Exception
    {
        public UsernameOrPasswordWrongException() : base("Username or Password is wrong")
        {
        }

        public UsernameOrPasswordWrongException(string? message) : base(message)
        {
        }
    }
}
