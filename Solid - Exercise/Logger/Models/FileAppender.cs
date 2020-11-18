using System;
using System.Collections.Generic;
using System.Text;

using LoggerProblem.Contracts;
using LoggerProblem.Enumerations;
using LoggerProblem.IOManagement;
using LoggerProblem.IOManagement.Contracts;

namespace LoggerProblem.Models
{
    public class FileAppender : Appender
    {
        private readonly IWriter writer;

        public FileAppender(ILayout _layout, Level _level, IFile _file)
            : base(_layout, _level)
        {
            this.File = _file;
            this.writer = new FileWriter(this.File.Path);
        }

        public IFile File { get; } 

        public override void Append(IError error)
        {
            string formattedMessage = this.File.Write(this.Layout, error);

            this.writer.WriteLine(formattedMessage);
            this.messagesAppended++;
        }

        public override string ToString()
        {
            return base.ToString() + $" File size {this.File.Size}";
        }
    }
}
