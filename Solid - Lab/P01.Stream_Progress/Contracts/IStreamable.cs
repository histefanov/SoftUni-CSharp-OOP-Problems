﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress.Contracts
{
    public interface IStreamable
    {
        public int Length { get; }
        public int BytesSent { get; }
    }
}
