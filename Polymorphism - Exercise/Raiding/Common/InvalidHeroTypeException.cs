using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Common
{
    public class InvalidHeroTypeException : Exception
    {
        public InvalidHeroTypeException(string message) 
            : base(message)
        {
        }
    }
}
