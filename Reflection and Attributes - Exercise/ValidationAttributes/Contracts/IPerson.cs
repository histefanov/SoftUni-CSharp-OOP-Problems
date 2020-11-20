using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Contracts
{
    public interface IPerson
    {
        public string FullName { get; }

        public int Age { get; }
    }
}
