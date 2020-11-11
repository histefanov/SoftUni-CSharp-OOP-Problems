using System;

namespace EnterNumbers
{
    public class Program
    {
        public const int START = 1;
        public const int END = 100;
        public const int NUM_COUNT = 10;

        static void Main(string[] args)
        {
            int[] numbers = new int[10];

            for (int i = 0; i < NUM_COUNT; i++)
            {
                try
                {
                    int currentNumber = ReadNumber(START, END);
                    numbers[i] = currentNumber;
                }
                catch (InvalidNumberException ine)
                {
                    Console.WriteLine(ine.Message);
                    i = -1;
                }
            }

            Console.WriteLine($"Entered numbers: {string.Join(", ", numbers)}");
        }

        public static int ReadNumber(int start, int end)
        {
            int currentNumber = int.Parse(Console.ReadLine());
            if (currentNumber <= 1 || currentNumber >= 100)
            {
                throw new InvalidNumberException(
                    "Entered number was out of bounds. All numbers must be between (1...100).");
            }
            return currentNumber;
        }
    }
}
