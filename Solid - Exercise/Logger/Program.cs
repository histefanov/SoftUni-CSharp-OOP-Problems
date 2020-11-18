using System;
using System.Collections.Generic;

using LoggerProblem.Models;
using LoggerProblem.IOManagement;
using Logger.Core.Contracts;
using Logger.Core;
using LoggerProblem.Common;
using LoggerProblem.Contracts;
using LoggerProblem.Enumerations;
using LoggerProblem.Factories;
using LoggerProblem.IOManagement.Contracts;

namespace LoggerProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory();

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IPathManager pathManager = new PathManager("logs", "logs.txt");
            IFile file = new LogFile(pathManager); 

            ILogger logger = SetUpLogger(n, writer, reader, file, layoutFactory, appenderFactory);

            IEngine engine = new Engine(logger, reader, writer);
            engine.Run();
        }

        private static ILogger SetUpLogger(
            int appendersCount, 
            IWriter writer, 
            IReader reader, 
            IFile file,
            LayoutFactory layoutFactory,
            AppenderFactory appenderFactory)
        {
            ICollection<IAppender> appenders = new HashSet<IAppender>();

            for (int i = 0; i < appendersCount; i++)
            {
                string[] appenderArgs = Console.ReadLine()
                    .Split(' ',
                    StringSplitOptions.RemoveEmptyEntries);

                string appenderType = appenderArgs[0];
                string layoutType = appenderArgs[1];

                Level appenderLevel = Level.INFO;

                if (appenderArgs.Length == 3)
                {
                    bool isEnumValid = Enum.TryParse(typeof(Level),
                        appenderArgs[2], true, out object enumParsed);

                    if (!isEnumValid)
                    {
                        writer.WriteLine(GlobalConstants.INVALID_LEVEL_TYPE);
                        continue;
                    }

                    appenderLevel = (Level)enumParsed;
                }

                try
                {
                    ILayout layout = layoutFactory.CreateLayout(layoutType);
                    IAppender appender = appenderFactory.CreateAppender(
                        appenderType, layout, appenderLevel, file);

                    appenders.Add(appender);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            ILogger logger = new ErrorLogger(appenders);
            return logger;
        }
    }
}
