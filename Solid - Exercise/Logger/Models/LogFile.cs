using LoggerProblem.Common;
using LoggerProblem.Contracts;
using LoggerProblem.Enumerations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LoggerProblem.Models
{
    public class LogFile : IFile
    {
        private readonly IPathManager pathManager;

        public LogFile(IPathManager _pathManager)
        {
            this.pathManager = _pathManager;
            this.pathManager.EnsureDirectoryAndFileExistence();
        }

        public string Path
            => this.pathManager.CurrentFilePath;

        public long Size
            => this.CalculateFileSize();

        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;

            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formattedMessage = String
                .Format(format,
                dateTime.ToString(GlobalConstants.DATETIME_FORMAT),
                level.ToString(),
                message);

            return formattedMessage;
        }

        private long CalculateFileSize()
        {
            string fileText = File.ReadAllText(this.Path);
            return fileText
                .ToCharArray()
                .Where(c => Char.IsLetter(c))
                .Sum(c => c);
        }
    }
}
