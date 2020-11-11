using System;
using System.Collections.Generic;
using System.Text;

namespace ValidPerson
{
    public class InvalidPersonNameException : ArgumentException
    {
        public InvalidPersonNameException()
        { }

        public InvalidPersonNameException(string message)
            : base(message)
        { }
    }
}
