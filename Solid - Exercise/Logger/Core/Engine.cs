using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

using Logger.Core.Contracts;
using LoggerProblem.Common;
using LoggerProblem.Contracts;
using LoggerProblem.Enumerations;
using LoggerProblem.Factories;
using LoggerProblem.IOManagement.Contracts;
using LoggerProblem.Models;

namespace Logger.Core
{
    public class Engine : IEngine
    {
        private readonly ILogger logger;
        private readonly IReader reader;
        private readonly IWriter writer;
        

        public Engine(ILogger _logger, IReader _reader, IWriter _writer)
        {
            this.logger = _logger;
            this.reader = _reader;
            this.writer = _writer;
        }

        public void Run()
        {
            string cmd;
            while ((cmd = reader.ReadLine()) != "END")
            {
                string[] errorArgs = cmd
                    .Split('|');

                string levelStr = errorArgs[0];
                string dateTimeStr = errorArgs[1];
                string message = errorArgs[2];

                bool isLevelValid = Enum.TryParse(typeof(Level),
                    levelStr, true, out object levelObj);

                if (!isLevelValid)
                {
                    this.writer.WriteLine(GlobalConstants.INVALID_LEVEL_TYPE);
                    continue;
                }

                Level level = (Level)levelObj;

                bool isDateTimeValid = DateTime.TryParseExact
                    (dateTimeStr, GlobalConstants.DATETIME_FORMAT,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime dateTime);

                if (!isDateTimeValid)
                {
                    this.writer.WriteLine(GlobalConstants.INVALID_DATETIME_FORMAT);
                    continue;
                }

                IError error = new Error(dateTime, message, level);

                this.logger.Log(error);
            }

            this.writer.WriteLine(this.logger.ToString());
        }
    }
}
