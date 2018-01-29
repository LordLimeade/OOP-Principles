using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystemDatabase.Exceptions
{
    public class InvalidMealPlanException : Exception
    {
        public InvalidMealPlanException()
        {
        }

        public InvalidMealPlanException(string message) : base(message)
        {
        }

        public InvalidMealPlanException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
