using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystemDatabase.Exceptions
{
    public class InvalidAssignmentNameException : Exception
    {
        public InvalidAssignmentNameException()
        {
        }

        public InvalidAssignmentNameException(string message) : base(message)
        {
        }

        public InvalidAssignmentNameException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
