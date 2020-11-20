using System;

using CommandPattern.IOManagement.Contracts;

namespace CommandPattern.IOManagement.Models
{
    class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
