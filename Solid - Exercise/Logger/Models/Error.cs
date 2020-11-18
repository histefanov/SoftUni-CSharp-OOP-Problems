using LoggerProblem.Contracts;
using LoggerProblem.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProblem.Models
{
    public class Error : IError
    {
        public Error(DateTime _dateTime, string _message, Level _level)
        {
            this.DateTime = _dateTime;
            this.Message = _message;
            this.Level = _level;
        }

        public DateTime DateTime { get; }
        public string Message { get; }
        public Level Level { get; }
    }
}
