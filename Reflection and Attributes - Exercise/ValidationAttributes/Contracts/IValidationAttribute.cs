using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Contracts
{
    public interface IValidationAttribute
    {
        public bool IsValid(object obj);
    }
}
