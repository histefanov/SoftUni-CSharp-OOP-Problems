using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerProblem.Contracts
{
    public interface IPathManager
    {
        string CurrentDirectoryPath { get; }

        string CurrentFilePath { get; }

        string GetCurrentPath();

        void EnsureDirectoryAndFileExistence();
    }
}
