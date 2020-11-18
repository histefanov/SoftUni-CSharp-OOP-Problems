using LoggerProblem.Common;
using LoggerProblem.Contracts;
using LoggerProblem.Enumerations;
using LoggerProblem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProblem.Factories
{
    public class AppenderFactory
    {
        public AppenderFactory()
        { }

        public IAppender CreateAppender (
            string appenderType, 
            ILayout layout, 
            Level level, 
            IFile file = null)
        {
            IAppender appender;

            if (appenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout, level);
            }
            else if (appenderType == "FileAppender")
            {
                appender = new FileAppender(layout, level, file);
            }
            else
            {
                throw new InvalidOperationException(GlobalConstants.INVALID_APPENDER_TYPE);
            }

            return appender;
        }
    }
}
