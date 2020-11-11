using System;
using System.Collections.Generic;
using System.Text;

namespace EnterNumbers
{
    public class InvalidNumberException : Exception
    {
        public InvalidNumberException()
        { }

        public InvalidNumberException(string message)
            : base(message)
        { }
    }
}
