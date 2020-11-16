using System;
using System.Collections.Generic;
using System.Text;

using P01.Stream_Progress.Contracts;

namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private readonly IStreamable file;

        public StreamProgressInfo(IStreamable _file)
        {
            this.file = _file;
        }

        public int CalculateCurrentPercent()
        {
            return (this.file.BytesSent * 100) / this.file.Length;
        }
    }
}
