using LoggerProblem.IOManagement.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LoggerProblem.IOManagement
{
    public class FileWriter : IWriter
    {     
        public FileWriter(string _filePath)
        {
            this.FilePath = _filePath;
        }

        public string FilePath { get; }

        public void Write(string text)
        {
            File.WriteAllText(this.FilePath, text);
        }

        public void WriteLine(string text)
        {
            File.WriteAllText(this.FilePath, text
                + Environment.NewLine);
        }
    }
}
