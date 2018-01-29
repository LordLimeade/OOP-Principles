using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystemDatabase.Exceptions
{
    public class StudentIDNotFoundException : Exception
    {
        public StudentIDNotFoundException()
        {
        }

        public StudentIDNotFoundException(string message) : base(message)
        {
        }

        public StudentIDNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
