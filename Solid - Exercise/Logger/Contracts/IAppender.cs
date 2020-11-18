using LoggerProblem.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProblem.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }
        
        Level Level { get; }

        void Append(IError error);
    }
}
