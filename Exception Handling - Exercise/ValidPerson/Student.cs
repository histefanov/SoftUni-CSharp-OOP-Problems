using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValidPerson
{
    public class Student 
    {
        private string name;

        public Student(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }

        public string Name 
        { 
            get { return this.name; }
            private set
            {
                if (!value.All(c => Char.IsLetter(c)))
                {
                    throw new InvalidPersonNameException("Name can only contain letters");
                }
                this.name = value;
            }
        }
        public string Email { get; set; }
    }
}
