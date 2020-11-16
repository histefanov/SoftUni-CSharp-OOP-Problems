using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
}
