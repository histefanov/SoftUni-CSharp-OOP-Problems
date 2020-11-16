using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Detail_Printer.Contracts
{
    public interface IWorker
    {
        public string Name { get; }

        public string GetInfo();
    }
}
