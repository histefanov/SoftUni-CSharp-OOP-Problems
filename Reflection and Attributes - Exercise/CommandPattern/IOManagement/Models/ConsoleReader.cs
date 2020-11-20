using System;

using CommandPattern.IOManagement.Contracts;

namespace CommandPattern.IOManagement.Models
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
