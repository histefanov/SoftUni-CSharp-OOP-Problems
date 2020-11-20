using System;
using System.Collections.Generic;
using System.Text;

using ValidationAttributes.Attributes;
using ValidationAttributes.Contracts;

namespace ValidationAttributes.Models
{
    public class Person : IPerson
    {
        public Person(string _fullName, int _age)
        {
            this.FullName = _fullName;
            this.Age = _age;
        }

        [MyRequiredAttribute]
        public string FullName { get; set; }

        [MyRangeAttribute(12,90)]
        public int Age { get; set; }
    }
}
