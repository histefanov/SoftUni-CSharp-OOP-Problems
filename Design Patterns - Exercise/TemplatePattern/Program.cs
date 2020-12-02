using System;
using System.Collections.Generic;

namespace TemplatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Bread> bakeryOrders = new List<Bread>();

            Bread sourdough = new Sourdough();
            bakeryOrders.Add(sourdough);

            Bread twelveGrain = new TwelveGrain();
            bakeryOrders.Add(twelveGrain);

            Bread wholeWheat = new WholeWheat();
            bakeryOrders.Add(wholeWheat);

            foreach (var order in bakeryOrders)
            {
                order.Make();
                Console.WriteLine();
            }
        }
    }
}
