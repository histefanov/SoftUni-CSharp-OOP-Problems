using System;
using System.Collections.Generic;
using System.Text;

using LoggerProblem.Contracts;

namespace LoggerProblem.Models
{
    public class ErrorLogger : ILogger
    {
        private readonly ICollection<IAppender> appenders;

        public ErrorLogger(ICollection<IAppender> _appenders)
        {
            this.appenders = _appenders;
        }

        public ErrorLogger(params IAppender[] _appenders)
        {
            this.appenders = _appenders;
        }

        public IReadOnlyCollection<IAppender> Appenders
            => (IReadOnlyCollection<IAppender>)this.appenders;

        public void Log(IError error)
        {
            foreach (IAppender appender in this.Appenders)
            {
                if (error.Level >= appender.Level)
                {
                    appender.Append(error);
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Logger info:");

            foreach (IAppender appender in this.Appenders)
            {
                sb.AppendLine(appender.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
