using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMANDS_NAMESPACE = "CommandPattern.Core.Models.";

        public string Read(string args)
        {
            string[] argsArr = args
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string commandName = (argsArr[0] + "Command").ToLower();
            string[] commandArgs = argsArr
                .Skip(1)
                .ToArray();

            var cmdType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == commandName);

            ICommand cmdInstance = Activator.CreateInstance(cmdType) as ICommand;

            return cmdInstance.Execute(commandArgs);
        }
    }
}
