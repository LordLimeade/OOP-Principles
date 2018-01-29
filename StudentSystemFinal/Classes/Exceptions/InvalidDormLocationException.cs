using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystemDatabase.Exceptions
{
    public class InvalidDormLocationException : Exception
    {
        public InvalidDormLocationException()
        {
        }

        public InvalidDormLocationException(string message) : base(message)
        {
        }

        public InvalidDormLocationException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
