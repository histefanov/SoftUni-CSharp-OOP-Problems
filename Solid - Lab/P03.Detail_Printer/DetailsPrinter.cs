using System;
using System.Collections.Generic;
using System.Text;

using P03.Detail_Printer.Contracts;

namespace P03.DetailPrinter
{
    public class DetailsPrinter
    {
        private IList<IWorker> workers;

        public DetailsPrinter(IList<IWorker> _workers)
        {
            this.workers = _workers;
        }

        public void PrintDetails()
        {
            foreach (IWorker worker in this.workers)
            {
                this.PrintWorker(worker);
            }
        }

        private void PrintWorker(IWorker worker)
        {
            Console.WriteLine(worker.GetInfo());
        }
    }
}
