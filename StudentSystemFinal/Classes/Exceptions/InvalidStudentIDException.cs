using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystemDatabase.Exceptions
{
    public class InvalidStudentIDException : Exception
    {
        public InvalidStudentIDException()
        {
        }

        public InvalidStudentIDException(string message) : base(message)
        {
        }

        public InvalidStudentIDException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
