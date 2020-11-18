using LoggerProblem.Contracts;
using LoggerProblem.Enumerations;
using LoggerProblem.IOManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProblem.Models
{
    public abstract class Appender : IAppender
    {
        protected int messagesAppended;

        protected Appender(ILayout _layout, Level _level)
        {
            this.Layout = _layout;
            this.Level = _level;
        }

        public ILayout Layout { get; }

        public Level Level { get; }

        public abstract void Append(IError error);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, " +
                   $"Report level: {this.Level}, Messages appended: {this.messagesAppended}";
        }
    }
}
