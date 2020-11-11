using System;

namespace SquareRoot
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                int n = int.Parse(Console.ReadLine());
                if (n <= 0)
                {
                    throw new InvalidNumberException("Invalid number");
                }
                else
                {
                    var result = Math.Sqrt(n);
                    Console.WriteLine(result);
                }
            }
            catch (InvalidNumberException ine)
            {
                Console.WriteLine(ine.Message);
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
