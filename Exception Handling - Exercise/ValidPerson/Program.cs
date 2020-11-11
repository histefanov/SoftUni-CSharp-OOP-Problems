using System;

namespace ValidPerson
{
    public class Program
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            try
            {
                var person = new Person(firstName, lastName, age);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("Exception thrown: {0}", ane.Message);
            }
            catch (ArgumentOutOfRangeException aoore)
            {
                Console.WriteLine("Exception thrown: {0}", aoore.Message);
            }

            string name = Console.ReadLine();
            string email = Console.ReadLine();

            try
            {
                var student = new Student(name, email);
            }
            catch (InvalidPersonNameException ipne)
            {
                Console.WriteLine("Exception thrown: {0}", ipne.Message);
            }
        }
    }
}
