using System;
using System.Collections.Generic;

using P03.Detail_Printer.Contracts;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            var employee = new Employee("Pesho");
            var manager = new Manager("Gosho", new List<string>() { 
                "CV", 
                "Documentation", 
                "Autobiography" });

            var detailsPrinter = new DetailsPrinter(new List<IWorker>() { employee, manager });
            detailsPrinter.PrintDetails();
        }
    }
}
