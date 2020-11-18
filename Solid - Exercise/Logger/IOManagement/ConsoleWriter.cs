using LoggerProblem.IOManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProblem.IOManagement
{
    public class ConsoleWriter : IWriter
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
