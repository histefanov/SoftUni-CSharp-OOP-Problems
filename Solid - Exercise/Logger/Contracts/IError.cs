using LoggerProblem.Enumerations;
using System;

namespace LoggerProblem.Contracts
{
    public interface IError
    {
        DateTime DateTime { get; }

        string Message { get; }

        Level Level { get; }
    }
}