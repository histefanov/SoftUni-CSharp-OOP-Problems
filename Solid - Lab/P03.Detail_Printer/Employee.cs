using System;
using System.Collections.Generic;
using System.Text;

using P03.Detail_Printer.Contracts;

namespace P03.DetailPrinter
{
    public class Employee : IWorker
    {
        public Employee(string _name)
        {
            this.Name = _name;
        }

        public string Name { get; set; }

        public virtual string GetInfo()
        {
            return this.Name;
        }
    }
}
