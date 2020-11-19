using System;
using System.Collections.Generic;
using System.Text;

namespace AuthorProblem
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, 
        AllowMultiple = true)]
    public class AuthorAttribute : Attribute
    {
        public AuthorAttribute(string _name)
        {
            this.Name = _name;
        }

        public string Name { get; set; }
    }
}
