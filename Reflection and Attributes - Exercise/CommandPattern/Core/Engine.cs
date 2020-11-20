using System;
using System.Collections.Generic;
using System.Text;

using CommandPattern.Core.Contracts;
using CommandPattern.IOManagement.Contracts;
using CommandPattern.IOManagement.Models;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        private readonly IReader reader;
        private readonly IWriter writer;

        private Engine()
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
        }

        public Engine(ICommandInterpreter _commandInterpreter)
            : this()
        {
            this.commandInterpreter = _commandInterpreter;
        }

        public void Run()
        {
            string cmd = this.reader.ReadLine();
            while (true)
            {
                var cmdResult = this.commandInterpreter.Read(cmd);
                this.writer.WriteLine(cmdResult);

                cmd = this.reader.ReadLine();
            }
        }
    }
}
