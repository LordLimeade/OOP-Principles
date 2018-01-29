using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystemDatabase.Exceptions
{
    public class InvalidStudentNameException : Exception
    {
        public InvalidStudentNameException()
        {
        }

        public InvalidStudentNameException(string message) : base(message)
        {
        }

        public InvalidStudentNameException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
