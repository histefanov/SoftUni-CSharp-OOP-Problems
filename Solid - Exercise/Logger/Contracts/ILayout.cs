using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProblem.Contracts
{
    public interface ILayout
    {
        string Format { get; }
    }
}
