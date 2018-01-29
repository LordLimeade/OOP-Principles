using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystemDatabase.Exceptions
{
    public class InvalidPointsPossibleException : Exception
    {
        public InvalidPointsPossibleException()
        {
        }

        public InvalidPointsPossibleException(string message) : base(message)
        {
        }

        public InvalidPointsPossibleException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
