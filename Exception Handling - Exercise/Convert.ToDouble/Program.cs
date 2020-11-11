using System;

namespace Convert.ToDouble
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double conversion;

            try
            {
                conversion = System.Convert.ToDouble(input);
                Console.WriteLine(Double.MaxValue);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                throw;
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
                throw;
            }
        }
    }
}
