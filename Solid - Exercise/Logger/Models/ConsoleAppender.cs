using System;
using System.Collections.Generic;
using System.Text;
using LoggerProblem.Common;
using LoggerProblem.Contracts;
using LoggerProblem.Enumerations;
using LoggerProblem.IOManagement;
using LoggerProblem.IOManagement.Contracts;

namespace LoggerProblem.Models
{
    class ConsoleAppender : Appender
    {
        private readonly IWriter writer;

        public ConsoleAppender(ILayout _layout, Level _level)
            : base(_layout, _level)
        {
            this.writer = new ConsoleWriter();
        }

        public override void Append(IError error)
        {
            string format = this.Layout.Format;

            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formattedString = String.Format(format,
                dateTime.ToString(GlobalConstants.DATETIME_FORMAT),
                level.ToString(),
                message);

            this.writer.WriteLine(formattedString);
            this.messagesAppended++;
        }
    }
}
