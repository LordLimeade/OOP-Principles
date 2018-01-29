using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystemDatabase.Exceptions
{
    public class InvalidPointsEarnedException : Exception
    {
        public InvalidPointsEarnedException()
        {
        }

        public InvalidPointsEarnedException(string message) : base(message)
        {
        }

        public InvalidPointsEarnedException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
