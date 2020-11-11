using System;
using System.Collections.Generic;
using System.Text;

namespace SquareRoot
{
    public class InvalidNumberException : Exception
    {
        public InvalidNumberException(string message)
            : base(message)
        { }
    }
}
