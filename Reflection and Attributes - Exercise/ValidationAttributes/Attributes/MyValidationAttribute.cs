using System;
using System.Collections.Generic;
using System.Text;
using ValidationAttributes.Contracts;

namespace ValidationAttributes.Attributes
{
    public abstract class MyValidationAttribute : Attribute, IValidationAttribute
    {
        public abstract bool IsValid(object obj);
    }
}
