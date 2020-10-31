using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private int age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age 
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age must be positive.");
                }
                else
                {
                    age = value;
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(String.Format("Name: {0}, Age: {1}",
                                    Name,
                                    Age));

            return sb.ToString();
        }
    }
}
